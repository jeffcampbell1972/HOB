using HOB.Services;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HOB.Web.Models
{
    public class ReportViewModel
    {
        public string Text { get; set; }
        public bool ShowReport { get; set; }

        [Display(Name="Report Text")]
        public string ReportText { get; set; }

        [Display(Name="Domain of Bigrams")]
        public List<string> Domain { get; set; }

        [Display(Name="Histogram")]
        public Histogram<StringBucket> Histogram { get; set; }
    }
}
