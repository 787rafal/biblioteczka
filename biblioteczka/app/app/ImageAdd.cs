using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace app
{
    public class ImageAdd
    {
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private int fileLocation;
        public int FileLocation
        {
            set { fileLocation = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
        }

        private string fileDatabaseName;
        public string FileDatabaseName
        {
            get { return fileDatabaseName; }
        }

        public ImageAdd()
        {
            filePath = "";
            fileLocation= 0;
            fileName = "";
            fileDatabaseName = "";
        }
        public void Image(string path)
        {
            this.filePath= path;
            this.fileLocation = path.LastIndexOf(@"\", StringComparison.OrdinalIgnoreCase);
            this.fileName = path.Substring(fileLocation);
            this.fileDatabaseName = "\\images" + fileName;

        }

        public void ImageCopy()
        {
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + fileDatabaseName))
            {
                File.Copy(FilePath, System.IO.Directory.GetCurrentDirectory() + fileDatabaseName);
            }
        }
        

    }
}
