using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Domain.Models;

namespace ZooApp.Web.Pages
{
    public class ÅbningstiderModel : PageModel
    {
        public List<OpenHours> ÅbningsTider { get; set; } = new List<OpenHours>();

        public void OnGet()
        {
            ÅbningsTider = new List<OpenHours>
            {
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Monday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Tuesday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Wednesday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(18,00),
                    IsClosed = false,
                    Note = null
                },
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Thursday,
                    OpenTime = new TimeOnly(14,30),
                    CloseTime = new TimeOnly(20,00),
                    IsClosed = false,
                    Note = null
                },
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Friday,
                    OpenTime = new TimeOnly(14,00),
                    CloseTime = new TimeOnly(22,00),
                    IsClosed = false,
                    Note = null
                },
                new OpenHours
                {
                    DayOfWeek = DayOfWeek.Saturday,
                    OpenTime = new TimeOnly(),
                    CloseTime = new TimeOnly(),
                    IsClosed = true,
                    Note = "Weekend"
                },
                new OpenHours
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
