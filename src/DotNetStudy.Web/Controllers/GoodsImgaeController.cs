using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStudy.Web.Controllers
{
    public class GoodsImgaeController :WebControllerBase
    {
        private readonly GoodsImgaeService _goodsImgaeService;
        private readonly GoodsService _goodsService;
        private readonly GoodTypeService _goodsTypeService;
        
        public GoodsImgaeController(GoodsService goodsService, GoodTypeService goodsTypeService, GoodsImgaeService goodsImgaeService,
           IServiceProvider serviceProvider)
           : base(serviceProvider)
        {
            _goodsImgaeService = goodsImgaeService;
            _goodsTypeService = goodsTypeService;
            _goodsService = goodsService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Show()
        {
          var goodsImgae= await  _goodsImgaeService.SelectAllAsync();
            return View(goodsImgae.ToList());
        }
        //public IActionResult AddGoodsImg()
        //{
        //    ViewBag.type = 1;
        //    return View();
        //}
       
        public  async  Task<IActionResult> AddGoodsImg(int id)
        {                                   
                var imgInfo =await  _goodsImgaeService.SelectByIdAsync(id);
                ViewBag.goodsId = id;
                return View(imgInfo);                                         
        }
        [HttpPost]
        public IActionResult AddGoodsImg(GoodsImgae goodsImgae)
        {
            //var imgInfo =await  _goodsImgaeService.SelectByIdAsync(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> saveGoodsImg([FromBody] GoodsImgae goodsImgae)
        {           
            await _goodsImgaeService.CreateAsync(goodsImgae);
            return View("Show");          
        }
        public IActionResult Update(int id)
        {            
            return View();
        }
        [HttpPost]
        public IActionResult Update(GoodsImgae goodsImgae)
        {
            var goodsImgaes = _goodsImgaeService.UpdateAsync(goodsImgae);
            return View();

        }
        //public JsonResult AddAsk([FromBody] AskModel model)
        //{
        //    return Json(model);
        //}


        public IActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]　　　　//上传文件是 post 方式，这里加不加都可以
        public async Task<IActionResult> UploadFiles(List<IFormFile> files, GoodsImgae goodsImgae)
        {
            long size = files.Sum(f => f.Length);
            //统计所有文件的大小
            string fileName = "";
            if (files.Count > 1)
            {
                foreach (var file in files)
                {
                    fileName += file.FileName + "/";
                }
            }
            else
            {
                foreach (var file in files)
                {
                    fileName += file.FileName;
                }
            }
            goodsImgae.GoodsImgaeName = fileName;
            goodsImgae.Size = size;
            var filepath = Directory.GetCurrentDirectory() + "\\wwwroot\\images";  //存储文件的路径
            ViewBag.log = "日志内容为：";     //记录日志内容

            foreach (var item in files)     //上传选定的文件列表
            {
                if (item.Length > 0)        //文件大小 0 才上传
                {
                    var thispath = filepath + "\\" + item.FileName;     //当前上传文件应存放的位置

                    if (System.IO.File.Exists(thispath) == true)        //如果文件已经存在,跳过此文件的上传
                    {
                        ViewBag.log += "\r\n文件已存在：" + thispath.ToString();
                        continue;
                    }

                    //上传文件
                    using (var stream = new FileStream(thispath, FileMode.Create))      //创建特定名称的文件流
                    {
                        try
                        {
                            await item.CopyToAsync(stream);     //上传文件
                        }
                        catch (Exception ex)        //上传异常处理
                        {
                            ViewBag.log += "\r\n" + ex.ToString();
                        }
                    }
                }
            }
            return RedirectToAction("AddGoodsImg", "GoodsImgae", goodsImgae);
        }
        public IActionResult Upload()
        {
            return View();
        }

        

       
    }
}
