using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HOB.Web.Models;
using HOB.Services;

namespace HOB.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IReportService<BigramHistogramReport> _histogramReportService;

        public HomeController(ILogger<HomeController> logger, IReportService<BigramHistogramReport> histogramReportService)
        {
            _logger = logger;
            _histogramReportService = histogramReportService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Report()
        {
            string exampleText = "Here is an example of bigrams example of bigram.  The period, comma, and period comma will be removed so 'period comma' should match period comma";
            var report = _histogramReportService.Generate(exampleText);

            var reportVM = new ReportViewModel
            {
                Text = "",
                ShowReport = true,
                ReportText = report.OriginalString,
                Domain = report.Domain,
                Histogram = report.Histogram
            };

            return View(reportVM);
        }
        [HttpPost]
        public IActionResult Report(ReportViewModel vm)
        {
            var report = _histogramReportService.Generate(vm.Text);

            var reportVM = new ReportViewModel
            {
                Text = "",
                ShowReport = true,
                ReportText = report.OriginalString,
                Domain = report.Domain,
                Histogram = report.Histogram
            };

            return View(reportVM);
        }
        public IActionResult FileReport()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
