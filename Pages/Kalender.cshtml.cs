using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using ZealandZoo.Models;

namespace ZealandZoo.Pages
{
    public class KalenderModel : PageModel
    {
        public List<Models.OpenHours> ÅbningsTider { get; set; } = new List<Models.OpenHours>();

        //public List<Models.Event> Events { get; set; } = new List<Models.Event>();

        //public List<OpenHours> SortByDate()
        //{
        //    var sortedEvents = Events
        //    .OrderBy(e => e.StartDateTime)
        //  .ToList();
        //}
        
        public void OnGet()
        {
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
                      OpenTime = new TimeOnly(14, 30),
                      CloseTime = new TimeOnly(18, 00),
                      IsClosed = false,
                      Note = null
                  },
                   new Models.OpenHours
                   {
                       DayOfWeek = DayOfWeek.Thursday,
                       OpenTime = new TimeOnly(14, 30),
                       CloseTime = new TimeOnly(20, 00),
                       IsClosed = false,
                       Note = null
                   },
                    new Models.OpenHours
                    {
                        DayOfWeek = DayOfWeek.Friday,
                        OpenTime = new TimeOnly(14, 00),
                        CloseTime = new TimeOnly(22, 00),
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
