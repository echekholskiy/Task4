using Aquality.Selenium.Browsers;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Task4.Utils
{
    public class ScreenshotProvider
    {
        public string TakeScreenshot()
        {
            var image = GetImage();
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
            EnsureDirectoryExists(directory);
            var screenshotName = $"{DateTime.Now:yyyyMMdd_HHmmss}.png";
            var path = Path.Combine(directory, screenshotName);
            image.Save(path, ImageFormat.Png);
            return path;
        }

        private Image GetImage()
        {
            using (var stream = new MemoryStream(AqualityServices.Browser.GetScreenshot()))
            {
                return Image.FromStream(stream);
            }
        }

        private static void EnsureDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
    }
}
