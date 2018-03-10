using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobs.Models;

namespace TechJobs.ViewModels
{
    public class SearchJobsViewModel : BaseViewModel
    {
        //  Extract members common to JobFieldsViewModel
        // to BaseViewModel

        // The search results
        public List<Job> Jobs { get; set; }

        // The column to search, defaults to all
        public JobFieldType Column { get; set; } = JobFieldType.All;

        // The search value
        [Display(Name = "Keyword:")]
        [Required]
        public string Value { get; set; } = "";

        // All columns, for display

        // View title

        public SearchJobsViewModel()
        {

        }
    }
}
