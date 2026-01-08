using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrokerFinder.Areas.Broker.Controllers;

[Area("Broker")]
[Authorize(Roles = "Broker")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}