using MVCDemo.Models;
using MVCDemo.ViewModels;

namespace MVCDemo.Extentions
{
    public  static class Helper
    {

        public static string uploadFile(IFormFile _file, string folderPath)
        {
            var filename = Guid.NewGuid().ToString()  + Path.GetExtension(_file.FileName);
            using (var st = new FileStream(folderPath + "//" + filename, FileMode.Create))
            {
                _file.CopyTo(st);
                st.Flush();
            }
            return filename;
        }
        public static bool CheckFileSize(IFormFile _file, int allowedSize = 2)
        {
            return !(_file.Length >= allowedSize);
        }
        public static bool CheckExtension(IFormFile _file, List<string> allowedExtention)
        {
            var extention = Path.GetExtension(_file.FileName);

            return !(allowedExtention.Contains(extention));
        }

        public static void DeleteFile(string fullPath )
        { 
            var isExist = System.IO.File.Exists(fullPath);
            if (isExist)
            {
                System.IO.File.Delete(fullPath);
            }
        }
     

}
}
