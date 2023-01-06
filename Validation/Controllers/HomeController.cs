using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Validation.Models;
using Serialization;
using UserClass;

namespace Validation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Console.WriteLine("Invoking Home Controller index method.. ");
        return View();
    }

    public IActionResult Privacy()
    {
        Console.WriteLine("Invoking Home Controller Privacy method. ");
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Welcome()
    {
        return View();
    }

    public IActionResult Validation(string username, string password)
    {
        Console.WriteLine("User Name and Pass Validate--------"+Serialize.ValidateUser(username,password));
         Console.WriteLine("IN Validate UserName---------------"+username);
        Console.WriteLine("IN Validate Password--------------"+password);
        if(Serialize.ValidateUser(username,password)){
            return Redirect("/home/Welcome");
        }
        return Redirect("/home/SignUp");
    }

    public IActionResult SignUp()
    {
        return View();
    }
    
    public IActionResult CreateUser(string username, string password)
    {
        Console.WriteLine("IN IFFFFFFFFFFFFF---------------"+username);
        Console.WriteLine("IN IFFFFFFFFFFFFF--------------"+password);
        Serialize.InsertCredential(username, password);
        
        return Redirect("/home/UserDetails");

        
    }

    public IActionResult UserDetails(string username, string firstname,string lastname, string location, string phonenumber)
    {
        Console.WriteLine("IN IFFFFFFFFFFFFF");
        
        if(Serialize.InsertUserDetails( username,  firstname, lastname,  location,  phonenumber)){
            return Redirect("/home/Welcome");
        }

        return Redirect("/home/Index");
        
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
