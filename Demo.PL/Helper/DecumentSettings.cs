using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace Demo.PL.Helper
{
    public class DecumentSettings
    {
        public static string UploadFile(IFormFile file , string folderName)
        {
            //1. get located folder path 
            // var folderPath = @"D:\route\MVC\Day_2\AssAndPP\Demo.PL Solution\Demo.PL\wwwroot\Files\Imgs\";
            // var folderPath = Directory.GetCurrentDirectory() + "wwwroot/Files" + folderName; 
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", folderName);


            // 2. get file name and make its name unique

            var fileName = $"{Guid.NewGuid()}{Path.GetFileName( file.Name)}";

            // 3. get flie path

            var filePath = Path.Combine(folderPath, fileName);

            // 4. save file 

            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }

        public static void Delete(string fileName , string folderName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", folderName, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

    }
}
