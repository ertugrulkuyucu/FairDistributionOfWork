using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandoraXProject.Models
{
    public class Job
    {
        public string JobName { get; set; }
        public int DifficultyLevel { get; set; }

        public Job(string jobName, int level)
        {
            this.JobName = jobName;
            this.DifficultyLevel = level;
        }
    }
}