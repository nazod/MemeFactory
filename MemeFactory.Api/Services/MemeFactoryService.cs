using MemeFactory.Api.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace MemeFactory.Api.Services
{
    public class MemeFactoryService : IMemeFactoryService
    {
        public byte[]? AddText(IFormFile file, string text)
        {
            if(file == null || text == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    Bitmap bmp = new Bitmap(img);


                    RectangleF rectf = new RectangleF(250, 650, 360, 200);

                    Graphics g = Graphics.FromImage(bmp);

                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawString(text.ToUpper(), new Font("Impact", 80), Brushes.White, rectf);

                    g.Flush();

                    using (var stream = new MemoryStream())
                    {
                        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        return stream.ToArray();
                    }

                }
            }

        }
    }
}
