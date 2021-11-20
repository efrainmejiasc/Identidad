using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace ImageEMC
{
    public class ImagenCode
    {
        public static string CreadorCodigoQR(string source, string pathFile)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(source, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(8000, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Bitmap imagenTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imagenTemporal, new Size(new Point(200, 200)));
            imagen.Save(pathFile, ImageFormat.Png);

            return pathFile;
        }

        public static string ConvertImgTo64Base(string pathFile)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(pathFile);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            return base64ImageRepresentation;
        }

        public static void MarcaDeAgua(string path, string pathName)
        {
            Image image = Image.FromFile(path);
            Bitmap bmp = new Bitmap(image);
            Graphics graphicsobj = Graphics.FromImage(bmp);
            Brush brush = new SolidBrush(Color.FromArgb(80, 255, 255, 255));
            Point postionWaterMark = new Point((bmp.Width / 9), (bmp.Height - 50));
            graphicsobj.DrawString("www.tuidentidad.com", new System.Drawing.Font("Arial", 30, FontStyle.Bold, GraphicsUnit.Pixel), brush, postionWaterMark);
            Image img = (Image)bmp;
            img.Save(pathName, System.Drawing.Imaging.ImageFormat.Jpeg);
            graphicsobj.Dispose();
        }

        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }


            return destImage;
        }
    }
}
