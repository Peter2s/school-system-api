namespace school.Helpers
{
    public class UploadImageHelper
    {
        private IWebHostEnvironment environment;
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
        public UploadImageHelper(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public static string? SaveImage(IFormFile imageFile, string uploadDirectory)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var fileExtension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file extension. Only JPG, JPEG, PNG, and GIF files are allowed.");
            }

            var fileName = Guid.NewGuid().ToString() + fileExtension;
            if(!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }
            var filePath = Path.Combine(uploadDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
                stream.Close();
            }

            return filePath;

        }
    }
}
