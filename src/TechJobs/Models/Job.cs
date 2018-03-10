namespace TechJobs.Models
{
    public class Job
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public PositionType PositionType { get; set; }

        public Job()
        {
            ID = nextId;
            nextId++;
        }

    }

}

//job class just declaires the job object that consists of the individual job columns  and allows their values to be set and returned. 
// this class also sets the id of the job and increments each time an instance of a job is made
//nextId is staic because the value needs to stay fixed so that each time a job is created its id number increases by one
