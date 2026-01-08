using BrokerFinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrokerFinder.Controllers;

public class HomeController : Controller
{
    private readonly IBrokerService _brokerService;
    public HomeController(IBrokerService brokerService) => _brokerService = brokerService;

    public async Task<IActionResult> Index()
    {
        var (brokers, total) = await _brokerService.SearchAsync(null, null, 1, 6);
        return View(brokers);
    }
}