using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemMonitorowaniaWydatkowDomowych.Data;
using SystemMonitorowaniaWydatkowDomowych.Models;

namespace SystemMonitorowaniaWydatkowDomowych.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly KontekstBazyDanych _kontekst;

    public HomeController(ILogger<HomeController> logger, KontekstBazyDanych kontekst)
    {
        _logger = logger;
        _kontekst = kontekst;
    }

    public async Task<IActionResult> Index()
    {
        var wydatki = await _kontekst.Wydatki.ToListAsync();

        ViewBag.LiczbaWydatkow = wydatki.Count;
        ViewBag.SumaWydatkow = wydatki.Sum(w => w.Kwota);
        ViewBag.NajwiekszyWydatek = wydatki.Any() ? wydatki.Max(w => w.Kwota) : 0;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}



