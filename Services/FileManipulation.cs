namespace izaque_d3_avaliacao.Services
{
    internal class FileManipulation
    {
        private readonly string path;

        public FileManipulation(string path)
        {
            this.path = path;
            createFolderAndFile(path);
        }

        private void createFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            if (!File.Exists(path))
                File.Create(path).Close();
        }

        public List<string> readAllLines()
        {
            List<string> lines = new();

            using (StreamReader file = new(path))
                for  (string line = file.ReadLine(); line != null; line = file.ReadLine())
                    lines.Add(line);

            return lines;
        }

        public void rewriteFile(List<string> lines)
        {
            using (StreamWriter output = new(path))
                foreach (var line in lines)
                    output.Write(line + "\n");
        }

        public void appendLine(string line)
        {
            List<string> lines = readAllLines();
            lines.Add(line);
            rewriteFile(lines);
        }
    }
}
