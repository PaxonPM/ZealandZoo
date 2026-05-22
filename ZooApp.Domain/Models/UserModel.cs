using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ZooApp.Domain.Models;

namespace ZooApp.Domain.Models
{
    public class UserModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Navn er påkrævet")]
        [StringLength(50, ErrorMessage = "navn skal være under 50 tegn")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email er påkrævet")]
        [RegularExpression(@"^[^@\s]+@edu\.zealand\.dk$", ErrorMessage = "Email skal være en @edu.zealand.dk adresse")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefonnummer er påkrævet")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Telefonnummer skal være præcis 8 tal")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Telefonnummer må kun indeholde tal")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "kodeord er påkrævet")]
        public string PwHash { get; set; }
        public int RoleId { get; set; }
        public bool IsNotificationActive { get; set; }

        public UserModel() { }

        public UserModel(string name, string email, string telefon, string pwHash, int roleId, bool isNotificationActive)
        {
            
            Name = name;
            Email = email;
            Telefon = telefon;
            PwHash = pwHash;
            RoleId = roleId;
            IsNotificationActive = isNotificationActive;
        }
    }
}
