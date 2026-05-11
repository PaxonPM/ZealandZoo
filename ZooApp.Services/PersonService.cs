using ZooApp.Data.MockData;
using ZooApp.Domain.Models;
using ZooApp.Services.Interfaces;

namespace ZooApp.Services
{
    public class PersonService: IPersonService
    {
        public List<Person> GetNewsletterMembers()
        {
            return MockPersons.GetMockPersons().Where(p => p.IsNewsletterMember).ToList();
        }
    }
}
