
using System.ComponentModel.DataAnnotations;

namespace WeaponManager.Models
{
    public class Firearm : Weapon
    {
        [Required(ErrorMessage = "Zadejte úsťovou rychlost")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Musí být celé číslo")]
        [Display(Name = "Úsťová rychlost")]
        public int MuzzleVelocity { get; set; }

        [Required(ErrorMessage = "Zadejte kapacitu zásobníku")]
        [RegularExpression("^[0-9]*", ErrorMessage = "Musí být celé číslo")]
        [Display(Name = "Kapacita zásobníku")]
        public int MagazineCapacity { get; set; }
    }
}
