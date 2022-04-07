using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandoraXProject.Models
{
    public class Employee
    {        
        public string Name { get; set; }
        public string Surname { get; set; }

        public Employee(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }    
    }
}