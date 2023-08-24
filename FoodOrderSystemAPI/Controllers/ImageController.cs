using Microsoft.AspNetCore.Mvc;

namespace FoodOrderSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult<UploadFileDto> Upload(IFormFile file)
        {
            #region Checking Extension

            var extension = Path.GetExtension(file.FileName);

            //TODO: It's better to be part of appsettings.json
            var allowedExtenstions = new string[]
            {
            ".png",
            ".jpg",
            ".svg"
            };

            bool isExtensionAllowed = allowedExtenstions.Contains(extension,
                StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest(new UploadFileDto(false, "Extension is not valid"));
            }

            #endregion

            #region Checking Length

            bool isSizeAllowed = file.Length is > 0 and <= 4_000_000;
            //bool isSizeAllowed = file.Length > 0 && file.Length <= 4_000_000;
            if (!isSizeAllowed)
            {
                return BadRequest(new UploadFileDto(false, "Size is not allowed"));
            }

            #endregion

            #region Storing The Image

            var newFileName = $"{Guid.NewGuid()}{extension}";
            var currentDirectory = Environment.CurrentDirectory;
            var imagesPath = Path.Combine(currentDirectory, "..", "FoodOrderSystemAPI.FrontEnd", "src", "assets", "Images");
            var fullFilePath = Path.Combine(imagesPath, newFileName);

            using var stream = new FileStream(fullFilePath, FileMode.Create);
            file.CopyTo(stream);

            #endregion

            #region Generating URL

            //var url = $"{Request.Scheme}://{Request.Host}/UplaodedImages/{newFileName}";
            var url = $"assets/Images/{newFileName}";
            return new UploadFileDto(true, "Success", url);

            #endregion
        }
    }
}
