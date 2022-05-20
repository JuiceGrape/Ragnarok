using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Objects/Equipment/Weapon")]
public class WeaponBase : EquipmentBase
{
    public Attack BasicAttack;

    public Enums.Stat ScalingStat;

    public Enums.Element DamageType;

    public float MinDamage;
    public float MaxDamage;

    public override Enums.SlotType GetSlotType()
    {
        return Enums.SlotType.Weapon;
    }
}
