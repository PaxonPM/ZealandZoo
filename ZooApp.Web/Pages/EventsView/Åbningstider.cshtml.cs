//using Microsoft.AspNetCore.Mvc.RazorPages;
//using ZooApp.Domain.Models;

//namespace ZooApp.Web.Pages.EventsView
//{
//    public class ÅbningstiderModel : PageModel
//    {
//        public List<OpenHours> ÅbningsTider { get; set; } = new List<OpenHours>();

//        public void OnGet()
//        {
//            ÅbningsTider = new List<OpenHours>
//            {
                
//                new OpenHours
//                {
//                    DayOfWeek = DayOfWeek.Friday,
//                    OpenTime = new TimeOnly(14,00),
//                    CloseTime = new TimeOnly(22,00),
//                },
//                new OpenHours
//                {
//                    DayOfWeek = DayOfWeek.Saturday,
//                    OpenTime = new TimeOnly(),
//                    CloseTime = new TimeOnly(),
//                },
                
//            };
//        }
//    }
//}
