using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using FileManagement;
using FileManagementUtil;



namespace FileManagementConsole
{
    class Program
    {



        private static int CmdNum = 0;
        private static string[] FileList;
        private static Action<string> WorkAction;
        private static Stopwatch Sw_Thread = new Stopwatch();
        private static Stopwatch Sw_File = new Stopwatch();
        private static string TempStr;

        private static bool IsOk;




        static void Main(string[] args)
        {




            Init();
            Run();

        }

        private static void Run()
        {
            WorkAction = WorkMethod;
            while (true)
            {
                RunWay(Config.ThreadType);
            }
        }

        private static void RunWay(string threadType)
        {
            switch (threadType)
            {
                case "Singel":
                    Single();
                    break;
                case "Parallel":
                    ParallelThread();
                    break;
                default:
                    MyLibrary.Log.Error("线程类型错误。");
                    Thread.Sleep(100 * 1000);
                    break;

            }

            MyLibrary.Log.Info("等待新的Xml文件；\r\n" + "Xml文件路径：" + Config.XmlFilesPath + " 文件模型：" + Config.SearchPattern);
            while (Directory.GetFiles(Config.XmlFilesPath, Config.SearchPattern, SearchOption.AllDirectories).Length == 0)
            {
                Thread.Sleep(1 * 1000);
            }
        }


        private static void Init()
        {

            switch (Config.FileType)
            {
                case "0101":
                    if (Config.RedoDataConfig.IsOpen)
                    {
                        IsOk = DataClear.ChuShiHua(Config.RedoDataConfig.DataMark, Config.RedoDataConfig.BufferTime);
                        if (!IsOk)
                        {
                            MyLibrary.Log.Warn("过滤重复数据类初始化出错");
                        }
                    }
                    break;
                case "1201":
                    if (Config.RedoDataConfig.IsOpen)
                    {
                        IsOk = DataClear.ChuShiHua(Config.RedoDataConfig.DataMark, Config.RedoDataConfig.BufferTime);
                        if (!IsOk)
                        {
                            MyLibrary.Log.Warn("过滤重复数据类初始化出错");
                        }
                    }
                    break;
                case "3501":
                    if (Config.RedoDataConfig.IsOpen)
                    {
                        IsOk = DataClear.ChuShiHua(Config.RedoDataConfig.DataMark, Config.RedoDataConfig.BufferTime);
                        if (!IsOk)
                        {
                            MyLibrary.Log.Warn("过滤重复数据类初始化出错");
                        }
                    }
                    break;
                case "3521":
                    if (Config.RedoDataConfig.IsOpen)
                    {
                        IsOk = DataClear.ChuShiHua(Config.RedoDataConfig.DataMark, Config.RedoDataConfig.BufferTime);
                        if (!IsOk)
                        {
                            MyLibrary.Log.Warn("过滤重复数据类初始化出错");
                        }
                    }
                    break;

            }
        }

        static void Single()
        {

            Sw_Thread.Restart();

            FileList = Directory.GetFiles(Config.XmlFilesPath, Config.SearchPattern, SearchOption.AllDirectories);
            foreach (var file in FileList)
            {
                WorkMethod(file);
            }

            Sw_Thread.Stop();
            MyLibrary.Log.MonitorRunInfo(string.Format("单线程用时：DateTime总共花费{0}ms.", Sw_Thread.ElapsedMilliseconds));

        }
        static void ParallelThread()
        {
            Sw_Thread.Restart();

            FileList = Directory.GetFiles(Config.XmlFilesPath, Config.SearchPattern, SearchOption.AllDirectories);
            Parallel.ForEach(FileList, new ParallelOptions() { MaxDegreeOfParallelism = Config.MaxDegreeOfParallelism }, WorkAction);

            Sw_Thread.Stop();

            MyLibrary.Log.MonitorRunInfo(string.Format("多线程用时：DateTime总共花费{0}ms.", Sw_Thread.ElapsedMilliseconds));

        }
        static void WorkMethod(string file)
        {
            MyLibrary.Log.Info("当前处理文件；\r\n" + file);
            XmlFile xmlFile = null;
            try
            {
                xmlFile = new XmlFile(file);
                if (xmlFile.Load())
                {
                    CmdNum = xmlFile.Commands.Count;
                    MyLibrary.Log.MonitorRunInfo("文件名称：" + file + " 命令数量：" + CmdNum);

                    Sw_File.Restart();
                    foreach (var cmd in xmlFile.Commands)
                    {
                        cmd.Execute();
                    }
                    Sw_File.Stop();
                    MyLibrary.Log.MonitorRunInfo(file + "单个文件共花费：" + Sw_File.ElapsedMilliseconds + "ms.");
                    TempStr = Math.Ceiling((double)Sw_File.ElapsedMilliseconds / (double)CmdNum).ToString(); //平均处理每个命令时间              
                    MyLibrary.Log.MonitorRunInfo(string.Format("平均每个命令花费{0}ms.", TempStr));
                    xmlFile.MoveTo(Config.NewXmlFilesPath);
                }
                else
                {
                    xmlFile.MoveTo(Config.ErrorXmlFilesPath);
                }
            }
            catch (Exception ex)
            {
                MyLibrary.Log.Error(ex.ToString());
                xmlFile.MoveTo(Config.ErrorXmlFilesPath);
                Thread.Sleep(3 * 1000);
            }
        }



    }
}
