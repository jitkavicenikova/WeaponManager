using System.ComponentModel.DataAnnotations;

namespace WeaponManager.Data.Enums
{
    public enum RifleType
    {
        [Display(Name = "Lovecká")]
        HuntingRifle,
        [Display(Name = "Vojenská")]
        MilitaryRifle
    }
}
