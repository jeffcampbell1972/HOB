using System;

namespace HOB.Services
{
    public class BigramHistogramReportService : IReportService<BigramHistogramReport>
    {
        private ICleaningService _cleaningService { get; set; }
        private IParsingService _parsingService { get; set; }
        private IBigramService _bigramService { get; set; }
        private IHistogramService _histogramService { get; set; }

        public BigramHistogramReportService(ICleaningService cleaningService, IParsingService parsingService, IBigramService bigramService, IHistogramService histogramService)
        {
            _cleaningService = cleaningService;
            _parsingService = parsingService;
            _bigramService = bigramService;
            _histogramService = histogramService;
        }
        public BigramHistogramReport Generate(string text)
        {
            string cleanedText = "";
            try
            {
                cleanedText = _cleaningService.Clean(text);
            }
            catch (Exception ex)
            {
                throw new InvalidTextException(ex.Message);
            }

            var words = _parsingService.Parse(cleanedText);

            if (words.Count == 1)
            {
                throw new InvalidTextException("No bigrams found.");
            }
            var bigrams = _bigramService.Extract(words);
            var domain = _histogramService.BuildStringDomain(bigrams);
            var histogram = _histogramService.Generate(domain);

            var histogramReport = new BigramHistogramReport
            {
                OriginalString = text,
                Domain = bigrams,
                Histogram = histogram
            };

            return histogramReport;
        }
    }
}
