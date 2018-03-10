using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;
using TechJobs.Data;
using TechJobs.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace TechJobs.Controllers
{
    public class ListController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static ListController ()
        {
            jobData = JobData.GetInstance();
        }

        // Lists options for browsing, by "column"
        public IActionResult Index()
        {
            JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();
            jobFieldsViewModel.Title = "View Job Fields";

            return View(jobFieldsViewModel);
        }

        // Lists the values of a given column, or all jobs if selected
        public IActionResult Values(JobFieldType column)
        {
            if (column.Equals(JobFieldType.All))
            {
                SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
                jobsViewModel.Jobs = jobData.Jobs;
                jobsViewModel.Title =  "All Jobs";
                return View("Jobs", jobsViewModel);
            }
            else
            {
                JobFieldsViewModel jobFieldsViewModel = new JobFieldsViewModel();

                IEnumerable<JobField> fields; //this is an instance of a list called fields, its data type is JobField
                //it will hold the jobs found from the search 

                switch (column)
                {
                  //switch cases that take a column type and adds all jobs in jobdata that match to a list
                  //while converting it to a jobfield object 
                 
                    case JobFieldType.Employer:
                        fields = jobData.Employers.ToList().Cast<JobField>();
                        break;
                    case JobFieldType.Location:
                        fields = jobData.Locations.ToList().Cast<JobField>();
                        break;
                    case JobFieldType.CoreCompetency:
                        fields = jobData.CoreCompetencies.ToList().Cast<JobField>();
                        break;
                    case JobFieldType.PositionType:
                    default:
                        fields = jobData.PositionTypes.ToList().Cast<JobField>();
                        break;
                }

                jobFieldsViewModel.Fields = fields; //view model that will take all the jobs found and pass it to view 
                jobFieldsViewModel.Title =  "All " + column + " Values";
                jobFieldsViewModel.Column = column;

                return View(jobFieldsViewModel);
            }
        }

        // Lists Jobs with a given field matching a given value
        public IActionResult Jobs(JobFieldType column, string value)
        {
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            jobsViewModel.Jobs = jobData.FindByColumnAndValue(column, value);
            jobsViewModel.Title = "Jobs with " + column + ": " + value;

            return View(jobsViewModel);
        }
    }
}
