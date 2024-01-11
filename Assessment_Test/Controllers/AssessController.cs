using Microsoft.AspNetCore.Mvc;

public class AssessController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Type_Assess()
    {
        return View("~/Views/Home/Type_Assess.cshtml");
    }

    public IActionResult Data_Entry()
    {
        return View("~/Views/Home/Data_Entry.cshtml");
    }
}
