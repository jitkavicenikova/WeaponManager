using System.ComponentModel.DataAnnotations;
using WeaponManager.Data.Enums;

namespace WeaponManager.Models
{
    public class ColdWeapon : Weapon
    {
        [Required(ErrorMessage = "Zadejte délku ostří")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage = "Neplatný formát")]
        [Display(Name="Délka ostří")]
        public decimal BladeLength { get; set; }
        [Required(ErrorMessage = "Zadejte hmotnost")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage = "Neplatný formát")]
        [Display(Name = "Hmotnost")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "Vyberte typ zbraně")]
        [Display(Name = "Typ")]
        public ColdWeaponType Type { get; set; }
    }
}
