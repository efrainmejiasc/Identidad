using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Drawing;
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
    }
}
