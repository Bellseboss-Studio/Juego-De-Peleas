namespace ServiceLocator
{
    public class SearchFile : ISearchFile
    {
        public string ReadFile(string path)
        {
            string line;
            string result = "";
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            while ((line = file.ReadLine()) != null)
            {
                result += line;
            }
            file.Close();
            return result;
        }
    }
}