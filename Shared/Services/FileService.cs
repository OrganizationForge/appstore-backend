using Application.Common.Interfaces;
using Application.DTOs;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using PuppeteerSharp;
using PuppeteerSharp.Media;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Shared.Services
{
    public class FileService : IFileService
    {
        public string UploadFile(FileUpload file, string route)
        {
            var pathToSave = Path.Combine("/app/resources/images", route);
            string fileRoute = "";

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);
            try
            {
                //if (file != null)
                //{
                //    var fileName = file.Name;
                //    var fullPath = Path.Combine(pathToSave, fileName);
                //    using (var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        // Convert the base64 string to a byte array
                //        string base64Data = Regex.Match(file.Data, "data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                //        var imageBytes = Convert.FromBase64String(base64Data);

                //        // Write the byte array to the stream to create the image file
                //        stream.Write(imageBytes, 0, imageBytes.Length);
                //        fileRoute = Path.Combine(route, fileName);
                //        //fileRoute = Path.Combine(folderName, fileName);
                //    }
                //}

                if (file != null)
                {
                    var fileName = file.Name;
                    var fullPath = Path.Combine(pathToSave, fileName);

                    // Convert the base64 string to a byte array
                    string base64Data = Regex.Match(file.Data, "data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                    var imageBytes = Convert.FromBase64String(base64Data);

                    // Load the image from the byte array
                    using (var ms = new MemoryStream(imageBytes))
                    using (var img = System.Drawing.Image.FromStream(ms))
                    {
                        // Calculate new size while maintaining aspect ratio
                        var newSize = CalculateNewSize(img.Width, img.Height, 518, 518);

                        // Resize the image
                        using (var resizedImg = new Bitmap(img, newSize))
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                // Save the resized image to the file stream
                                resizedImg.Save(stream, img.RawFormat);
                                fileRoute = Path.Combine(route, fileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return fileRoute;
        }

        // Helper method to calculate the new image size while maintaining aspect ratio
        private Size CalculateNewSize(int originalWidth, int originalHeight, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / originalWidth;
            var ratioY = (double)maxHeight / originalHeight;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(originalWidth * ratio);
            var newHeight = (int)(originalHeight * ratio);

            return new Size(newWidth, newHeight);
        }

        public string UploadFile(IFormFile file, string route)
        {

            var folderName = Path.Combine("Resources", route);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            string fileRoute = "";

            if (!Directory.Exists(pathToSave))
                Directory.CreateDirectory(pathToSave);
            try
            {
                if (file != null)
                {
                    var fileName = file.FileName;
                    var fullPath = Path.Combine(pathToSave, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        fileRoute = Path.Combine(folderName, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return fileRoute;
        }

        public async Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
    where T : class
        {
            //if (request == null || request.Data == null)
            //{
            //    return string.Empty;
            //}

            //if (request.Extension is null || !supportedFileType.GetDescriptionList().Contains(request.Extension.ToLower()))
            //    throw new InvalidOperationException("File Format Not Supported.");
            //if (request.Name is null)
            //    throw new InvalidOperationException("Name is required.");

            //string base64Data = Regex.Match(request.Data, "data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;

            //var streamData = new MemoryStream(Convert.FromBase64String(base64Data));
            //if (streamData.Length > 0)
            //{
            //    string folder = typeof(T).Name;
            //    if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            //    {
            //        folder = folder.Replace(@"\", "/");
            //    }

            //    string folderName = supportedFileType switch
            //    {
            //        FileType.Image => Path.Combine("Files", "Images", folder),
            //        _ => Path.Combine("Files", "Others", folder),
            //    };
            //    string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            //    Directory.CreateDirectory(pathToSave);

            //    string fileName = request.Name.Trim('"');
            //    fileName = RemoveSpecialCharacters(fileName);
            //    fileName = fileName.ReplaceWhitespace("-");
            //    fileName += request.Extension.Trim();
            //    string fullPath = Path.Combine(pathToSave, fileName);
            //    string dbPath = Path.Combine(folderName, fileName);
            //    if (File.Exists(dbPath))
            //    {
            //        dbPath = NextAvailableFilename(dbPath);
            //        fullPath = NextAvailableFilename(fullPath);
            //    }

            //    using var stream = new FileStream(fullPath, FileMode.Create);
            //    await streamData.CopyToAsync(stream, cancellationToken);
            //    return dbPath.Replace("\\", "/");
            //}
            //else
            //{
            //    return string.Empty;
            //}

            return string.Empty;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", string.Empty, RegexOptions.Compiled);
        }

        public void Remove(string? path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        private const string NumberPattern = "-{0}";

        private static string NextAvailableFilename(string path)
        {
            if (!File.Exists(path))
            {
                return path;
            }

            if (Path.HasExtension(path))
            {
                return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path), StringComparison.Ordinal), NumberPattern));
            }

            return GetNextFilename(path + NumberPattern);
        }

        private static string GetNextFilename(string pattern)
        {
            string tmp = string.Format(pattern, 1);

            if (!File.Exists(tmp))
            {
                return tmp;
            }

            int min = 1, max = 2;

            while (File.Exists(string.Format(pattern, max)))
            {
                min = max;
                max *= 2;
            }

            while (max != min + 1)
            {
                int pivot = (max + min) / 2;
                if (File.Exists(string.Format(pattern, pivot)))
                {
                    min = pivot;
                }
                else
                {
                    max = pivot;
                }
            }

            return string.Format(pattern, max);
        }


        public async Task<byte[]> ConvertHtmlToPdfAsync(string htmlContent)
        {
           
            var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

           
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            await using var page = await browser.NewPageAsync();

          
            await page.SetContentAsync(htmlContent);

            var pdfOptions = new PdfOptions
            {
                Format = PaperFormat.A4,
                DisplayHeaderFooter = true,
                MarginOptions = new MarginOptions
                {
                    Top = "20px",
                    Right = "20px",
                    Bottom = "40px",
                    Left = "20px"
                },
                HeaderTemplate = "<div style='font-size:10px !important; color:#808080; text-align:right; margin-right:10px;'>Página [page] de [toPage]</div>",
                FooterTemplate = "<div style='font-size:10px !important; color:#808080; text-align:center;'>Generated by Append</div>"
            };

            var pdfContent = await page.PdfDataAsync(pdfOptions);
            return pdfContent;
        }
    }
}
