using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Equipment
{
    public Attack Attack { get; private set; }

    public Weapon(WeaponBase obj, Enums.Rarity rarity) : base(obj, rarity)
    {
        Attack = obj.BasicAttack;
    }
}
