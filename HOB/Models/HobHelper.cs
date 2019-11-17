using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using HOB.Services;

namespace HOB
{
    public class HobHelper :IHobHelper
    {
        private IReportService<BigramHistogramReport> _histogramReportService;
        private IFileService _fileService;
        public HobHelper(IReportService<BigramHistogramReport> histogramReportService, IFileService fileService)
        {
            _fileService = fileService;
            _histogramReportService = histogramReportService;
        }

        public string[] GetHobForConsole(string text)
        {
            string[] consoleOutput;

            try
            {
                var report = _histogramReportService.Generate(text);

                consoleOutput = PrepareConsoleOutput(report);
            }
            catch
            {
                consoleOutput = new string[] { "Exception." };
            }

            return consoleOutput;
        }
        public string[] GetHobForConsoleFromFile(string filename)
        {
            string[] consoleOutput;
            string text = "";

            try
            {
                text = _fileService.ExtractText(filename);
            }
            catch (FileNotFoundException)
            {
                consoleOutput = new string[] { "** Error - File not found.  No report generated." };
            }
            catch (InvalidFileTypeException)
            {
                consoleOutput = new string[] { "** Error - Invalid file type provided.  No report generated." };
            }
            catch (ReadAllTextException)
            {
                consoleOutput = new string[] { "** Error - Error reading text from file.  No report generated." };
            }

            consoleOutput = GetHobForConsole(text);

            return consoleOutput;
        }
        private string[] PrepareConsoleOutput(BigramHistogramReport report)
        {
            var consoleOutput = report.Histogram.Buckets.OrderByDescending(x => x.Count).Select(x => x.Value + " => " + x.Count.ToString()).ToArray();

            return consoleOutput;
        }
    }
}
