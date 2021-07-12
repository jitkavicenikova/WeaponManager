using System.ComponentModel.DataAnnotations;

namespace WeaponManager.Models
{
    public abstract class Weapon
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zadejte název")]
        [Display(Name = "Název")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zadejte cenu")]
        [RegularExpression("^[0-9]+([.]?)[0-9]*", ErrorMessage ="Neplatný formát")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

    }
}
