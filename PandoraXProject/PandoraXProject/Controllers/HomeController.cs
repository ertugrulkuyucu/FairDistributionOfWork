using PandoraXProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandoraXProject.Controllers
{
    public class HomeController : Controller
    {     
            public ActionResult Index()
            {
            List<List<string>> allSchedules = new List<List<string>>();

            List<Employee> EmployeeList = new List<Employee>()
            {
                new Employee("Ertugrul","Kuyucu"),
                new Employee("Serkan","Diker"),
                new Employee("Emre", "Sagir"),
                new Employee("Berke", "Gul"),
                new Employee("Umut", "Buyukyildiz"),
                new Employee("Ali", "Aksoy")
            };

            List<Job> jobList = new List<Job>()
            {
                new Job("Catlak kontrolu yap",1),
                new Job("Kamyon sur", 2),
                new Job("LHD sur", 3),
                new Job("Tahkimat yap", 4),
                new Job("Patlatma Deliklerini hazirla", 5),
                new Job("Patlayici yerlestir", 6)
            };

            Random random = new Random();
            int randomNumber;

            //setSchedule ile her bir isciye farkli is verilecek. yani islerin unique sahipleri olacak.
            List<string> setSchedule()
            {
                List<string> schedule = new List<string>();
                //bu dongu ile iscilere sirayla gorev ataniyor(i personeli temsil ediyor)
                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    schedule.Add(EmployeeList[i].Name.ToString() + " " + EmployeeList[i].Surname.ToString());
                    //point noktasi islerin sirali olmamasi icin kodu yeniden random kismina almasi icin kondu 
                point1:
                    randomNumber = random.Next(0, 6);
                    //ilk kisiye is verilmis mi kontrolu saglaniyor
                    if (i != 0)
                    {
                        //bu dongude verilen random is daha once bu listede kullanilmis mi kontrolu yapiliyor
                        for (int a = 1; a < schedule.Count; a += 2)
                        {
                            if (schedule[a].ToString() == jobList[randomNumber].JobName.ToString())
                            {
                                goto point1;
                            }
                        }
                        schedule.Add(jobList[randomNumber].JobName.ToString());
                    }
                    else
                        schedule.Add(jobList[randomNumber].JobName.ToString());
                }
                return schedule;
            }

            //bu dongu gorevlerin esit dagilmasi icin her gun farkli olmasi icin
            for (int x = 0; x < 6; x++)
            {
            point2:
                List<string> temp = new List<string>();
                List<string> temp2 = new List<string>();
                temp = setSchedule();

                if (x != 0)
                {
                    for (int q = 0; q < allSchedules.Count; q++)
                    {
                        temp2 = allSchedules[q];

                        for (int i = 1; i < temp.Count; i += 2)
                        {
                            if (temp2[i] == temp[i])
                            {
                                goto point2;
                            }
                        }
                    }
                    allSchedules.Add(temp);
                }
                else
                    allSchedules.Add(setSchedule());
            }
            return View(allSchedules);
        }
    }
}