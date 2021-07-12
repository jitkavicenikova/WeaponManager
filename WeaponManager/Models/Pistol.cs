using System.ComponentModel.DataAnnotations;
using WeaponManager.Data.Enums;

namespace WeaponManager.Models
{
    public class Pistol : Firearm
    {
        [Required(ErrorMessage = "Zadejte hmotnost")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage = "Neplatný formát")]
        [Display(Name = "Hmotnost")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "Zadejte dostřel")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Musí být celé číslo")]
        [Display(Name = "Dostřel")]
        public int PistolRange { get; set; }

        [Display(Name = "Typ")]
        [Required(ErrorMessage = "Vyberte typ")]
        public PistolType PistolType { get; set; }
    }
}
