using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpecEd
{
    public partial class SpritePropertiesDialog : Form
    {
        private SpriteInstance m_instance = new SpriteInstance();

        public SpritePropertiesDialog()
        {
            InitializeComponent();
        }

        public SpriteInstance SpriteInstance
        {
            get
            {
                m_instance.startX = Convert.ToInt32(udStartX.Value);
                m_instance.startY = Convert.ToInt32(udStartY.Value);
                m_instance.deltaMin = Convert.ToInt32(udMinimum.Value);
                m_instance.deltaMax = Convert.ToInt32(udMaximum.Value);
                m_instance.speed = Convert.ToInt32(udSpeed.Value) | (Convert.ToInt32(udFrameSpeed.Value) << 3);
                m_instance.colour = Convert.ToInt32(udColour.Value);
                m_instance.evaluator = tbEvaluator.Text;

                return m_instance;
            }
            set
            {
                m_instance = value;

                if (m_instance.colour < 1 || m_instance.colour > 7) {
                    m_instance.colour = 6;
                }

                udStartX.Value = m_instance.startX;
                udStartY.Value = m_instance.startY;
                udMinimum.Value = m_instance.deltaMin;
                udMaximum.Value = m_instance.deltaMax;
                udSpeed.Value = (m_instance.speed & 7);
                udFrameSpeed.Value = ((m_instance.speed >> 3) & 31);
                udColour.Value = m_instance.colour;
                tbEvaluator.Text = m_instance.evaluator;
            }
        }
    }
}
