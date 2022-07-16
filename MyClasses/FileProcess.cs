namespace MyClasses
{
    public class FileProcess
    {
        public bool FileExists(string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName))
            {
                throw new
                    ArgumentNullException("filename");
            }

            return File.Exists(fileName);
        }

    }
}