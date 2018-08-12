using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Decision.Util
{
    public static class BitMapUtil
    {
        public static Bitmap ByteToImage(byte[] blob)
        {
            //********************************
            //* Protege contra bitmaps vazios
            //********************************
            try
            {
                //**************************************
                //* Converte array de bytes para imagem
                //**************************************
                MemoryStream mStream = new MemoryStream();
                byte[] pData = blob;
                mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
                Bitmap bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            catch
            {
                return new Bitmap(1, 1);
            }
        }
        public static Bitmap GetBestFitThumb(Bitmap oImage, Int32 MaxWidth, Int32 MaxHeight)
        {
            //********************************
            //* Obtem bitmap mantendo aspecto
            //********************************
            var ratioX = (double)MaxWidth / oImage.Width;
            var ratioY = (double)MaxHeight / oImage.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(oImage.Width * ratio);
            var newHeight = (int)(oImage.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            var graphics = Graphics.FromImage(newImage);
            graphics.InterpolationMode = InterpolationMode.High;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.DrawImage(oImage, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}