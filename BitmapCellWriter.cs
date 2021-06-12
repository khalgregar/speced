using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace SpecEd
{
    public class BitmapCellWriter : IDisposable
    {
        private Bitmap m_bitmap;
        private BitmapData m_bitmapData;
        private byte[] m_bytes = new byte[8*4];

        private readonly static byte[,] s_shapes = {
            { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff },
            { 0x01, 0x03, 0x07, 0x0f, 0x1f, 0x3f, 0x7f, 0xff },
            { 0x80, 0xc0, 0xe0, 0xf0, 0xf8, 0xfc, 0xfe, 0xff },
            { 0xff, 0x7f, 0x3f, 0x1f, 0x0f, 0x07, 0x03, 0x01 },
            { 0xff, 0xfe, 0xfc, 0xf8, 0xf0, 0xfe, 0xfc, 0xf8 }
        };

        public BitmapCellWriter(Bitmap _bitmap)
        {
            m_bitmap = _bitmap;
            Lock();
        }

        private void Lock()
        {
            m_bitmapData = m_bitmap.LockBits(new Rectangle(0, 0, m_bitmap.Width, m_bitmap.Height), ImageLockMode.WriteOnly, m_bitmap.PixelFormat);
        }

        private void Unlock()
        {
            if (m_bitmapData != null)
            {
                m_bitmap.UnlockBits(m_bitmapData);
                m_bitmapData = null;
            }
        }

        public unsafe void RenderCell(CharacterCell _cell, int _tileX, int _tileY)
        {
            byte* pBase = (byte*)m_bitmapData.Scan0;
            pBase = pBase + m_bitmapData.Stride*_tileY* 8 + _tileX * 8 * 4;
            
            for (int rowIdx = 0; rowIdx < 8; ++rowIdx)
            {
                byte row = _cell.rows[rowIdx];
                uint* ppixel = (uint*)(pBase + rowIdx*m_bitmapData.Stride);
                for (int bitIdx = 7; bitIdx >= 0; --bitIdx)
                {
                    bool isSet = ((row >> bitIdx) & 1) > 0;
                    Color[] cols = _cell.colour.IsBright ? SpectrumColours.coloursBright : SpectrumColours.colours;
                    Color col = isSet ? cols[_cell.colour.Ink] : cols[_cell.colour.Paper];
                    *ppixel++ = (uint)col.ToArgb();
                }
            }
        }

        public unsafe void RenderByte(byte _b, int _tileX, int _lineY)
        {
            byte* pBase = (byte*)m_bitmapData.Scan0;
            uint* ppixel = (uint*)(pBase + m_bitmapData.Stride * _lineY + _tileX * 8 * 4);
            
            for (int bitIdx = 7; bitIdx >= 0; --bitIdx)
            {
                bool isSet = ((_b >> bitIdx) & 1) > 0;
                Color col = isSet ? SpectrumColours.colours[SpectrumColours.WHITE] : SpectrumColours.colours[SpectrumColours.BLACK];
                *ppixel++ = (uint)col.ToArgb();
            }
        }

        public unsafe void RenderSprite(Sprite _sprite, int _frame, int _tileX, int _tileY, int _col = 7)
        {
            int frame = _frame % _sprite.numFrames;
            byte* pBase = (byte*)m_bitmapData.Scan0;
            pBase = pBase + m_bitmapData.Stride * _tileY * 8 + _tileX * 8 * 4;

            for (int y = 0; y < _sprite.tileHeight; ++y)
            {
                for (int rowIdx = 0; rowIdx < 8; ++rowIdx)
                {
                    int scanline = y * 8 + rowIdx;
                    uint* ppixel = (uint*)(pBase + m_bitmapData.Stride * scanline);
                    for (int x = 0; x < _sprite.tileWidth; ++x)
                    {
                        byte b = _sprite.frames[frame, x, scanline];
                        for (int bitIdx = 7; bitIdx >= 0; --bitIdx)
                        {
                            bool isSet = ((b >> bitIdx) & 1) > 0;
                            Color col = isSet ? SpectrumColours.colours[_col] : SpectrumColours.colours[SpectrumColours.BLACK];
                            *ppixel++ = (uint)col.ToArgb();
                        }
                    }
                }
            }
        }

        public unsafe void RenderSpriteMask(Sprite _sprite, int _frame, int _tileX, int _tileY)
        {
            int frame = _frame % _sprite.numFrames;
            byte* pBase = (byte*)m_bitmapData.Scan0;
            pBase = pBase + m_bitmapData.Stride * _tileY * 8 + _tileX * 8 * 4;

            for (int y = 0; y < _sprite.tileHeight; ++y)
            {
                for (int rowIdx = 0; rowIdx < 8; ++rowIdx)
                {
                    int scanline = y * 8 + rowIdx;
                    uint* ppixel = (uint*)(pBase + m_bitmapData.Stride * scanline);
                    for (int x = 0; x < _sprite.tileWidth; ++x)
                    {
                        byte b = _sprite.masks[frame, x, scanline];
                        for (int bitIdx = 7; bitIdx >= 0; --bitIdx)
                        {
                            bool isSet = ((b >> bitIdx) & 1) > 0;
                            int alpha = isSet ? 92 : 0;
                            Color col = Color.FromArgb(alpha, Color.Red);
                            *ppixel++ = (uint)col.ToArgb();
                        }
                    }
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Unlock();
                }
                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
