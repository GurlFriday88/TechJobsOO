using Microsoft.AspNetCore.Mvc;
using TechJobs.Data;
using TechJobs.Models;
using TechJobs.ViewModels;

namespace TechJobs.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        {
            // get the Job with the given ID and pass it into the view
            
            Job match = jobData.Find(id);
           


            return View(match);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            // Validate the ViewModel and if valid, 
            // create a new Job and
            // add it to the JobData data store. Then
            // redirect to the Job detail (Index) action/view for the new Job.
            if (ModelState.IsValid)
            {
                
                Job job = new Job
                {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationId),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyId),
                    PositionType= jobData.PositionTypes.Find(newJobViewModel.PositionTypeId),

                };

                jobData.Jobs.Add(job);

                return Redirect(string.Format("/Job?id={0}", job.ID));
            }

            return View(newJobViewModel);
        }
    }
}
