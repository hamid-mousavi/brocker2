using BrokerFinder.ViewModels;
using BrokerFinder.Services;
using Microsoft.AspNetCore.Mvc;

namespace BrokerFinder.Controllers;

public class BrokersController : Controller
{
    private readonly IBrokerService _brokerService;
    public BrokersController(IBrokerService brokerService) => _brokerService = brokerService;

    public async Task<IActionResult> Index(string? port, string? specialty, int page = 1)
    {
        var (list, totalPages) = await _brokerService.SearchAsync(port, specialty, page);
        var vm = new BrokerListViewModel { Brokers = list, Page = page, TotalPages = totalPages };
        return View(vm);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var b = await _brokerService.GetByIdAsync(id);
        if (b == null) return NotFound();
        var creds = await _brokerService.GetCredentialsAsync(id);
        var vm = new BrokerDetailsViewModel { Broker = b, Credentials = creds };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Contact(Guid brokerId, string contactEmail, string? message)
    {
        var broker = await _brokerService.GetByIdAsync(brokerId);
        if (broker == null) return NotFound();

        await _brokerService.LogContactAsync(brokerId, contactEmail, message);

        TempData["Message"] = "پیام شما ارسال شد، متشکریم.";
        return RedirectToAction("Details", new { id = brokerId });
    }
}