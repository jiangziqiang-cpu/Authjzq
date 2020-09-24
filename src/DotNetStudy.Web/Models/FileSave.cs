using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Models
{
    public class FileSave
    {
        public FileSave()
        {
            FileInfos = new List<FileInfo>();


        }
        public List<FileInfo> FileInfos { get; set; }

        /// <summary>
        /// 文件上传成功或失败的消息 fail 和true
        /// </summary>
        public string Message { get; set; }
    }

    public class FileInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }



    }
}
