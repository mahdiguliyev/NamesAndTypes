using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NamesAndTypes.Data;
using NamesAndTypes.Models;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NamesAndTypes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToastNotification _toastNotification;
        private readonly ApplicationDbContext _context;

        public HomeController(IToastNotification toastNotification, ApplicationDbContext context)
        {
            _toastNotification = toastNotification;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(AddViewModel addViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(addViewModel.Name) && !string.IsNullOrEmpty(addViewModel.Type))
                {
                    var existedName = await _context.Employees.Where(e => e.NameOfWorker == addViewModel.Name.Trim()).FirstOrDefaultAsync();
                    if (existedName == null)
                    {
                        Employee employee = new Employee
                        {
                            NameOfWorker = addViewModel.Name.Trim(),
                            Type = addViewModel.Type.Trim(),
                            CreatedDate = DateTime.Now
                        };
                        WType type = new WType
                        {
                            Type = addViewModel.Type,
                            CreatedDate = DateTime.Now
                        };

                        await _context.Employees.AddAsync(employee);
                        await _context.Types.AddAsync(type);
                        await _context.SaveChangesAsync();

                        _toastNotification.AddSuccessToastMessage("Data is added!", new ToastrOptions
                        {
                            Title = "Success"
                        });
                        return RedirectToAction("index", "home");
                    }
                    _toastNotification.AddErrorToastMessage("The name is taken. Please, provide another name!", new ToastrOptions
                    {
                        Title = "Fail"
                    });
                    return RedirectToAction("index", "home");
                }
                _toastNotification.AddErrorToastMessage("Name or Type cannot be empty or null!", new ToastrOptions
                {
                    Title = "Fail"
                });
                return RedirectToAction("index", "home");
            }
            return View(addViewModel);
        }
        [HttpGet]
        public string GetTypes(string searchText)
        {
            var types = _context.Types.OrderBy(t => t.Id).Take(5).Where(t => t.Type.StartsWith(searchText));
            string serializedData = JsonSerializer.Serialize(types);

            return serializedData;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
