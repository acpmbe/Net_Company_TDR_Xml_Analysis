using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FileManagementUtil;

namespace FileManagement
{
    public class XmlFile_Bll
    {

        private static string[] FileList;

        private static List<string> ListFile;
        private static DirectoryInfo Dir;
        private static FileInfo[] FileInfo;

    

        static string[] GetValidFile(string InvalidStr)
        {

            ListFile = new List<string>();
            Dir = new DirectoryInfo(Config.XmlFilesPath);
            FileInfo = Dir.GetFiles(Config.SearchPattern, SearchOption.AllDirectories);
            foreach (var v in FileInfo)
            {
                if (!v.DirectoryName.Contains(InvalidStr))
                {
                    ListFile.Add(v.FullName);
                }
            }

            return ListFile.ToArray();

        }


        public static string[] GetValidFile()
        {
            if (string.IsNullOrWhiteSpace(Config.InvalidPath))
            {
                FileList = Directory.GetFiles(Config.XmlFilesPath, Config.SearchPattern, SearchOption.AllDirectories);
            }
            else
            {
                FileList = GetValidFile(Config.InvalidPath);
            }
            return FileList;
        }

    }
}
