using System.ComponentModel.DataAnnotations;
using WeaponManager.Data.Enums;

namespace WeaponManager.Models
{
    public class Rifle : Firearm
    {
        [Required(ErrorMessage = "Zadejte ráži munice")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage = "Neplatný formát")]
        [Display(Name = "Ráže munice")]
        public decimal Caliber { get; set; }

        [Required(ErrorMessage = "Zadejte celkovou délku zbraně")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage = "Neplatný formát")]
        [Display(Name = "Celková délka zbraně")]
        public decimal RifleLength { get; set; }

        [Required(ErrorMessage = "Vyberte typ")]
        [Display(Name = "Typ")]
        public RifleType RifleType { get; set; }
    }
}
