using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.Services;
using DotNetStudy.Web.ViewModels.MyAddressViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetStudy.Web.Controllers
{
    public class MyAddressController :  WebControllerBase 
    {
        private readonly MyAddressService _myAddressService;
        public MyAddressController(MyAddressService myAddressService,
            IServiceProvider serviceProvider)
           : base(serviceProvider)
        {
            _myAddressService = myAddressService;
        }
        public async Task<IActionResult> Index()
        {
            if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
            {
                return Redirect("/Account/Login");
            } 
            var myAddresses = await _myAddressService.GetAllByUserIdAsync(Convert.ToInt32(userIdValue));
            var model = Mapper.Map<List<MyAddressModel>>(myAddresses);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveById(int myAddressId)
        {
            await _myAddressService.RemoveByIdAsync(myAddressId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddNewAddress()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewAddress(AddNewAddressModel model)
        {
            if (ModelState.IsValid)
            {
                if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
                {
                    return Redirect("/Account/Login");
                }
                model.UserId = Convert.ToInt32(userIdValue);
                var myAddress= Mapper.Map<MyAddress>(model);
                await _myAddressService.AddNewAddressAsync(myAddress);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var myAddress = await _myAddressService.GetByIdAsync(id);
            var myAddressInfo = Mapper.Map<MyAddressModel>(myAddress);
            return View(myAddressInfo);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateMyAddress(MyAddressModel model)
        {
            if (ModelState.IsValid)
            {
                var myAddress = await _myAddressService.EditByIdAsync(model.Id);
                if (myAddress == null)
                {
                    return NotFound();
                }
                if (!Request.Cookies.TryGetValue("UserId", out string userIdValue))
                {
                    return Redirect("/Account/Login");
                }
                model.UserId = Convert.ToInt32(userIdValue);
                myAddress = Mapper.Map(model, myAddress);
                await _myAddressService.UpdateMyAddressAsync(myAddress);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
