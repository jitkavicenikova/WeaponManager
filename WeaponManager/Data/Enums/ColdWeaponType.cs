using System.ComponentModel.DataAnnotations;

namespace WeaponManager.Data.Enums
{
    public enum ColdWeaponType
    {
        [Display(Name = "Meč")]
        Sword,
        [Display(Name = "Rapír")]
        Rapier,
        [Display(Name = "Dýka")]
        Dagger
    }
}
