using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetStudy.Web.Services
{
    public class FileSever
    {
        private IWebHostEnvironment _environment;
        public FileSever(IWebHostEnvironment environment)
        {
            _environment = environment;


        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public async Task<Models.FileSave> FileHelp(IFormFileCollection files)
        {
             Models.FileSave fileSave = new Models.FileSave();
           
            if (files.Count > 0)
            {
                fileSave.Message = "true";
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    // 上传目录处理
                    var fileProvider = _environment.WebRootFileProvider;
                    var fileInfo = fileProvider.GetFileInfo("images");
                    if (!fileInfo.Exists)
                    {
                        Directory.CreateDirectory(fileInfo.PhysicalPath);
                    }
                    // 文件类型过滤
                    var filters = new[] { "image/png", "image/jpeg", "image/gif" };
                    if (!filters.Contains(file.ContentType))
                    {
                        fileSave.Message = "fail";
                        return fileSave;
                    }
                    // 文件名处理
                    var extensionsName = file.FileName.Substring(file.FileName.LastIndexOf("."));
                    var newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + extensionsName;
                    var filePath = fileInfo.PhysicalPath + "\\" + newFileName;
                    // 写入文件
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    Models.FileInfo fileInfo1 = new Models.FileInfo()
                    {
                        FileName = newFileName,
                        Path = "/images/" + newFileName
                    };
                    fileSave.FileInfos.Add(fileInfo1);
                }         
                //更新用户图片数据
            }
            fileSave.Message = "fail";
            return fileSave;
            
        }

    }
}
