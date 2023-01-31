using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MVC_Music.ViewModels
{
    public class PerformanceFeeSummaryVM
    {
            public int ID { get; set; }

            [Display(Name = "Musician")]
            public string FullName
            {
                get
                {
                    return FirstName
                        + (string.IsNullOrEmpty(MiddleName) ? " " :
                            (" " + (char?)MiddleName[0] + ". ").ToUpper())
                        + LastName;
                }
            }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            [Display(Name = "Number of Performances")]
            public int NumberOfPerformances { get; set; }

            [Display(Name = "Average Fee Paid")]
            [DataType(DataType.Currency)]
            public double AverageFeePaid { get; set; }

            [Display(Name = "Maximum Fee Paid")]
            [DataType(DataType.Currency)]
            public double MaximumFeePaid { get; set; }

            [Display(Name = "Minimum Fee Charged")]
            [DataType(DataType.Currency)]
            public double MinimumFeePaid { get; set; }

    }
}
