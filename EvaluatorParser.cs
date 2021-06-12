using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecEd
{
    /*  GRAMMAR
     *  =======
     *  <name>        ::= ALPHA *( ALPHA / DIGIT / "_" / "-" )
     *  <integer>     ::= [("-"/ "+")] DIGIT *DIGIT
     *  <expr>        ::= (<function>/<integer>/<name>)
     *  <function>    ::= <name> "(" <expr> *{"," <expr>} ")"
     */

    // 00xx xxxx xxxx xxxx - object ID (0-8191)
    // 01xx xxxx xxxx xxxx - literal (0-255)
    // 10xx xxxx           - command (0-63)

    class EvaluatorParser
    {
        public Dictionary<string, int> NameTable { get; private set; }

        public EvaluatorParser(Dictionary<string,int> _nameTable)
        {
            NameTable = _nameTable;
        }

        private abstract class Symbol
        {
            public readonly List<Symbol> m_symbols = new List<Symbol>();
            public Symbol()
            { }
            
            public abstract void Write(Stream s, EvaluatorParser _parser);
        }

        private class Name : Symbol
        {
            // ALPHA *( ALPHA / DIGIT / "_" / "-" )

            public string Value { get; private set; }

            public override void Write(Stream s, EvaluatorParser _parser)
            {
                int objectId;
                if (!_parser.NameTable.TryGetValue( Value, out objectId ))
                {
                    throw new Exception( String.Format("Unrecongised name '{0}'", Value) );
                }
                s.WriteByte(0);
                s.WriteByte((byte)objectId);
            }

            public static Symbol Produce(string _s, ref int _idx)
            {
                var i = _idx;
                string str = String.Empty;
                char c = _s[i];
                if (!char.IsLetter(c))
                {
                    return null;
                }
                str += c;
                ++i;
                for (; i < _s.Length; ++i)
                {
                    c = _s[i];
                    if (!(char.IsLetterOrDigit(c) || c == '_' || c == '-'))
                    {
                        break;
                    }
                    str += c;
                }

                var o = new Name();
                o.Value = str;
                _idx = i;
                return o;
            }
        }

        private class IntegerLiteral : Symbol
        {
            public int Value { get; private set; }

            public override void Write(Stream s, EvaluatorParser _parser)
            {
                s.WriteByte(0x40);
                s.WriteByte((byte)Value);
            }

            public static Symbol Produce(string _s, ref int _idx)
            {
                var i = _idx;
                string str = String.Empty;
                char c = _s[i];
                if (c == '+' || c == '-')
                {
                    str += c;
                    ++i;
                }
                
                c = _s[i];
                if (!char.IsDigit(c))
                {
                    return null;
                }

                str += c;
                ++i;

                while (i < _s.Length)
                {
                    c = _s[i];
                    if (!char.IsDigit(c))
                    {
                        break;
                    }
                    str += c;
                    ++i;
                }

                var o = new IntegerLiteral();
                o.Value = Convert.ToInt32(str);
                _idx = i;
                return o;
            }
        }

        private class Expression : Symbol
        {
            public override void Write(Stream s, EvaluatorParser _parser)
            {
                // Not used.
            }

            public static Symbol Produce(string _s, ref int _idx)
            {
                var i = _idx;
                Symbol symbol = Function.Produce(_s, ref i);
                if (symbol == null)
                {
                    i = _idx;
                    symbol = Name.Produce(_s, ref i);
                    if (symbol == null)
                    {
                        i = _idx;
                        symbol = IntegerLiteral.Produce(_s, ref i);
                        if (symbol == null)
                        {
                            return null;
                        }
                    }
                }

                _idx = i;
                return symbol;
            }
        }

        private class Function : Symbol
        {
            // <name> "(" (<name>/<integer>/<function>) ["," (<name>/<integer>/<function>)] ")"

            private struct ExpressionFunction
            {
                public int numArgs;
                public int code;
            }

            private static readonly Dictionary<string, ExpressionFunction> s_commands = new Dictionary<string, ExpressionFunction>()
            {
                { "if",     new ExpressionFunction { numArgs = 3, code = 0} },
                { "and",    new ExpressionFunction { numArgs = 2, code = 1} },
                { "or",     new ExpressionFunction { numArgs = 2, code = 2} },
                { "xor",    new ExpressionFunction { numArgs = 2, code = 3} },
                { "not",    new ExpressionFunction { numArgs = 1, code = 4} },
                { "add",    new ExpressionFunction { numArgs = 2, code = 5} },
                { "sub",    new ExpressionFunction { numArgs = 2, code = 6} },
                { "eq",     new ExpressionFunction { numArgs = 2, code = 7} },
                { "neg",    new ExpressionFunction { numArgs = 1, code = 8} }
            };

            public override void Write(Stream s, EvaluatorParser _parser)
            {
                Name funcName = m_symbols[0] as Name;
                if (funcName == null)
                {
                    throw new Exception("Invalid function.");
                }

                ExpressionFunction ef;
                if (!s_commands.TryGetValue(funcName.Value, out ef))
                {
                    throw new Exception( String.Format("Unrecognised function '{0}'.", funcName.Value) );
                }

                var args = m_symbols.Skip(1);
                if (args.Count() != ef.numArgs)
                {
                    throw new Exception(String.Format("'{0}' function expected {1} args, got {2}", funcName.Value, ef.numArgs, args.Count()));
                }

                s.WriteByte((byte)(ef.code | 0x80));
                foreach (var arg in args)
                {
                    arg.Write(s, _parser);
                }
            }


            public static Symbol Produce(string _s, ref int _idx)
            {
                var o = new Function();
                var i = _idx;

                var funcName = Name.Produce(_s, ref i);
                if (funcName != null)
                {
                    o.m_symbols.Add(funcName);
                    if (i < _s.Length && _s[i++] == '(')
                    {
                        var expr = Expression.Produce(_s, ref i);
                        if (expr != null)
                        {
                            o.m_symbols.Add(expr);

                            while (i < _s.Length)
                            {
                                if (_s[i] == ')')
                                {
                                    _idx = ++i;
                                    return o;
                                }

                                if (_s[i++] != ',')
                                {
                                    break;
                                }

                                expr = Expression.Produce(_s, ref i);
                                if (expr == null)
                                {
                                    break;
                                }
                                o.m_symbols.Add(expr);
                            }
                        }
                    }
                }

                return null;
            }
        }

        public byte[] Parse(string _eval)
        {
            var i = 0;
            var expr = Expression.Produce(_eval, ref i);
            if (expr == null)
            {
                throw new Exception( string.Format("Error parsing evaluator '{0}'", _eval) );
            }

            byte[] bytes;
            using (var s = new MemoryStream())
            {
                expr.Write(s, this);
                bytes = s.ToArray();
            }

            return bytes;
        }
    }
}
