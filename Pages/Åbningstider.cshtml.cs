using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using ZealandZoo.MockData;
using ZealandZoo.Models;

namespace ZealandZoo.Pages
{
    public class ÅbningstiderModel : PageModel
    {
        //public List<Models.Event> Events { get; set; } = new List<Models.Event>();
        //public List<MockEvent> Events { get; set; } = new List<MockEvent>();
        public List<Models.OpenHours> ÅbningsTider { get; set; } = new List<Models.OpenHours>();
        public void OnGet()
        {
            //Events = new List<MockEvent>
            //{
            //    new MockEvent(),
            //    new MockEvent()



            //};
            //Events = new List<Event>
            //{
            //    new Event
            //    {

            //    }
            //    new Model.Event
            //    {
            //        Id = 1,
            //        Title = "Karaoke",
            //        Describtion = "Der bliver afholdt årets karaokebar",
            //        StartDateTime = 1-5-18.30,
            //        EndDateTime = 1-6-02.00,
            //        Location= "Kantinen",
            //        MaxParticipants = 300,
            //        CreatedAt = 28-4-10.00,
            //        CreatedById = 1
            //    },
            //      new Model.Event
            //    {
            //        Id = 1,
            //        Title = "Jule-Bar",
            //        Describtion = "Der bliver afholdt årets Jule-Bar",
            //        StartDateTime = 22-12-12.00,
            //        EndDateTime = 22-12-23.00,
            //        Location= "Zealand zoo bar",
            //        MaxParticipants = 100,
            //        CreatedAt = 28-4-10.00,
            //        CreatedById = 1
            //    },
            //};
         
            ÅbningsTider = new List<OpenHours>
            {
                new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Monday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },

                 new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Tuesday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },
                  new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Wednesday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },
                   new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Thursday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(20,00),
                    IsClosed = false,
                    Note = null
                },
                    new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Friday,
                    OpenTime = new TimeOnly(14,00),
                    CloseTime = new TimeOnly(22,00),
                    IsClosed = false,
                    Note = null
                },
                     new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Saturday,
                    OpenTime = new TimeOnly(),
                    CloseTime = new TimeOnly(),
                    IsClosed = true,
                    Note = "Weekend"
                },
                      new Models.OpenHours
                {
                    DayOfWeek = DayOfWeek.Sunday,
                    OpenTime = new TimeOnly(),
                    CloseTime = new TimeOnly(),
                    IsClosed = true,
                    Note = "Weekend"
                }
                     
            };
         
        }

       
     
    } 

    

       
        
        

}
    

