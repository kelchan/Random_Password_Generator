using Microsoft.AspNetCore.Mvc;
using PasswordGenerator;
namespace Home;

public class HomeController : Controller
{


    [ HttpGet("") ]
    public IActionResult Index()
    {
        HttpContext.Session.SetInt32( "count", 1 );
        Generator newPassword = new Generator();
        return View( "Index", newPassword );
    }


    [ HttpGet("/generate") ]
    public IActionResult GeneratePasscode()
    {
        int? count = HttpContext.Session.GetInt32( "count" );
        count++;
        Console.WriteLine( count );
        if( count.HasValue )
        {
            HttpContext.Session.SetInt32( "count", count.Value );
        }
        Generator newPassword = new Generator();

        return View( "Index", newPassword );
    }

}
