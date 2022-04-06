using ExcelProjesi.Data;
using ExcelProjesi.Models;
using ExcelProjesi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcelProjesi.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly Publisher publisher;


        public ProductController(ApplicationContext context, UserManager<AppUser> userManager, Publisher publisher)
        {
            _context = context;
            _userManager = userManager;
            this.publisher = publisher;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateExcel()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var fileName = $"product-excel-{Guid.NewGuid().ToString().Substring(1, 10)}";

            UserFile userfile = new()
            {
                UserId = user.Id,
                FileName = fileName,
                FileStatus = FileStatus.Creating
            };


            await _context.UserFiles.AddAsync(userfile);
            await _context.SaveChangesAsync();
            TempData["StartCreatingExcel"] = true;


            publisher.Publish(new CreateExcelMessage
            {
                UserId = userfile.UserId,
                FileId = userfile.Id
            });


            return RedirectToAction(nameof(Files));
        }

        public async Task<IActionResult> CreateProductExcel()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var fileName = $"product-excel-{Guid.NewGuid().ToString().Substring(1, 10)}";

            UserFile userfile = new()
            {
                UserId = user.Id,
                FileName = fileName,
                FileStatus = FileStatus.Creating
            };

            await _context.UserFiles.AddAsync(userfile);


            await _context.SaveChangesAsync();

            TempData["StartCreatingExcel"] = true;

            return RedirectToAction(nameof(Files));


        }

        public async Task<IActionResult> Files()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            return View(await _context.UserFiles.Where(x => x.UserId == user.Id).OrderByDescending(x => x.Id).ToListAsync());
        }
    }
}
