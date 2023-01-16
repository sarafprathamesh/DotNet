using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using BLL;
using BOL;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

     public IActionResult GetAllStudents()
    {
        HRManager mgr=new HRManager();
        this.ViewData["AllStudents"]=mgr.GetAllStudents();
        return View();
    }

     public IActionResult GetAllDepartments()
    {
        HRManager mgr=new HRManager();
        this.ViewData["AllDepartments"]=mgr.GetAllDepartments();
        return View();
    }

     public IActionResult InsertStudent(Student stud)
    {
        HRManager mgr=new HRManager();
        this.ViewData["InsertStudent"]=mgr.InsertStudent(stud);
        return View();
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
