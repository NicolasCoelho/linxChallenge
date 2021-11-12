namespace backend.Utilities
{
    class FilesUtilities
    {
        public string DirectoryPath;
        public string ImagePath;

        public FilesUtilities()
        {
            DirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Static");
            ImagePath = "images";
        }


        public string WriteImage(string base64, string ?fileName=null)
        {
            try
            {   
                string[] character = base64.Split(";base64,");
                string pureBase64 = character[1];
                byte[] bytes = Convert.FromBase64String(pureBase64);

                if (fileName == null) {
                    string fileType = character[0].Split("/")[1];
                    fileName = Guid.NewGuid().ToString() + "." + fileType;
                }
                string path = Path.Combine(DirectoryPath, ImagePath, fileName); 
                
                File.WriteAllBytes(path, bytes);
                return fileName;
            }
            catch (System.Exception)
            {   
                throw;
            }
        }

        public void DeleteImage(string fileName)
        {
            try
            {   
                string path = Path.Combine(DirectoryPath, ImagePath, fileName);
                File.Delete(path);    
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}