using FileManagementUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagement
{
    public class XmlFile
    {
        private string path;
        private FileInfo fileInfo;
        public List<ICommand> Commands { get; private set; }

        public XmlFile(string path)
        {
         
            this.path = path;
            Commands = new List<ICommand>();
            try
            {
                fileInfo = new FileInfo(path);
  
            }
            catch
            {
                MyLibrary.Log.Debug("初始化FileInfo出错；文件路径："+path);
            }
        }

        public bool Load()
        {
            if (!fileInfo.Exists)
            {
                MyLibrary.Log.Error("文件不存在；文件名：" + fileInfo.Name);
                return false;
            }
            XmlDocument doc = new XmlDocument();
            for (int i = 0; i <= 2; i++)
            {
                try
                {
                    string content = File.ReadAllText(path, Encoding.UTF8);
                    if (string.IsNullOrWhiteSpace(content))
                    {
                        MyLibrary.Log.Error(string.Format("文件{0}内容为空。", fileInfo.Name));
                        return false;
                    }
                    doc.LoadXml(content);
                    break;
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("another process"))
                    {
                        MyLibrary.Log.Error("读取文件错误；" + ex.Message + " 文件名：" + fileInfo.Name);

                    }
                    System.Threading.Thread.Sleep(2 * 1000);
                    if (i > 2)
                    {
                        return false;
                    }
                }
            }
            ICommandFactory cmdFactory = FileFactory.Create(fileInfo.Name, doc);
            if (cmdFactory == null)
            {
                MyLibrary.Log.Error("生成工厂接口出错。");
                return false;
            }
            Commands = cmdFactory.GetCommands();
            return true;
        }

        public bool MoveTo(string newPath)
        {
            try
            {
                newPath = Path.Combine(newPath, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                newPath = Path.Combine(newPath, fileInfo.Name);
                if (!File.Exists(path))
                {
                    MyLibrary.Log.Error("找不到文件；" + path);
                    return true;
                }
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }
                MyLibrary.Log.Info("移动文件到新目录；\r\n" + newPath);
                File.Move(path, newPath);
                return true;

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error("移动文件错误；" + ex.Message + " 文件：" + path);
                return false;
            }
        }

        public bool CopyTo(string newPath)
        {
            try
            {
                newPath = Path.Combine(newPath, DateTime.Now.ToString("yyyy-MM-dd"));
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                newPath = Path.Combine(newPath, fileInfo.Name);
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }
                MyLibrary.Log.Info("Copy the file to new path.\r\n" + newPath);
                File.Copy(path, newPath);
                return true;

            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(string.Format("throw exception when Copy {0} file.\r\n{1}", newPath, ex.ToString()));
                return false;
            }
        }
    }
}
