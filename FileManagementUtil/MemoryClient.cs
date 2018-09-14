using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;

namespace FileManagementUtil
{
    /// <summary>
    /// 共享内存客户端。
    /// </summary>
    //public static class MemoryClient
    //{


    //    private static MemoryMappedFile MemoryFile;
    //    private static MemoryMappedViewAccessor ViewAccessor;


    //    private static readonly object O_MemoryFile = new object();
    //    private static readonly object O_ViewAccessor = new object();
    //    private static readonly object O_Read = new object();
    //    private static readonly object O_Write = new object();


    //    public static string Created(string name, long size)
    //    {
    //        try
    //        {

    //            if (MemoryFile == null)
    //            {
    //                lock (O_MemoryFile)
    //                {
    //                    if (MemoryFile == null)
    //                    {
    //                        MemoryFile = MemoryMappedFile.OpenExisting(name);
    //                    }
    //                }
    //            }
    //            if (ViewAccessor == null)
    //            {
    //                lock (O_ViewAccessor)
    //                {
    //                    if (ViewAccessor == null)
    //                    {
    //                        ViewAccessor = MemoryFile.CreateViewAccessor(0, size);
    //                    }
    //                }
    //            }

    //            return "0";
    //        }
    //        catch (Exception ex)
    //        {
    //            return ex.Message;
    //        }
    //    }

    //    /// <summary>
    //    /// 初始化新的实例。
    //    /// </summary>
    //    /// <param name="_shareName">服务端共享内存文件名称。</param>
    //    /// <param name="_capacity">内存文件大小（单位字节）。</param>
    //    //public MemoryClient(string name, long size)
    //    //{
    //    //    this.Name = name;
    //    //    this.Size = size;
    //    //}

    //    /// <summary>
    //    /// 打开指定的内存空间（返回1成功，否则返回出错信息）。
    //    /// </summary>
    //    /// <returns>ss</returns>
    //    //public string Create()
    //    //{
    //    //    try
    //    //    {
    //    //        MemoryFile = MemoryMappedFile.OpenExisting(Name);
    //    //        ViewAccessor = MemoryFile.CreateViewAccessor(0, Size);
    //    //        return "0";
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        return ex.Message;
    //    //    }
    //    //}

    //    /// <summary>
    //    /// 写入内容。
    //    /// </summary>
    //    /// <param name="_content">内容。</param>
    //    public static void Write(string _content)
    //    {

    //        lock (O_Write)
    //        {
    //            ViewAccessor.Write(0, _content.Length);
    //            ViewAccessor.WriteArray<char>(4, _content.ToArray(), 0, _content.Length);
    //        }


    //    }


    //    /// <summary>
    //    /// 读取内容。
    //    /// </summary>
    //    /// <returns></returns>
    //    public static string Read()
    //    {
    //        lock (O_Read)
    //        {
    //            int strLength = ViewAccessor.ReadInt32(0);
    //            char[] charsInMMf = new char[strLength];
    //            //读取字符
    //            ViewAccessor.ReadArray<char>(4, charsInMMf, 0, strLength);
    //            return new string(charsInMMf);
    //        }

    //    }


    //}
}
