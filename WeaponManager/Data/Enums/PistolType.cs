using System.ComponentModel.DataAnnotations;

namespace WeaponManager.Data.Enums
{
    public enum PistolType
    {
        [Display(Name = "Revolver")]
        Revolver,
        [Display(Name = "Automat")]
        Automatic
    }
}
