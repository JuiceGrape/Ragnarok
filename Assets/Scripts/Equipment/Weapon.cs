using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : Equipment
{
    public Attack Attack { get; private set; }

    float minAttack;
    float maxAttack;

    public Weapon(WeaponBase obj, Enums.Rarity rarity) : base(obj, rarity)
    {

        Attack = obj.BasicAttack;

        minAttack = obj.MinDamage * Enums.GetMultiplierFromRarity(rarity);
        maxAttack = obj.MaxDamage * Enums.GetMultiplierFromRarity(rarity);
    }

    public Tuple<float, float> GetDamageRange(Statistics stats)
    {
        float min = 0;
        float max = maxAttack;

        return new Tuple<float, float>(min, max);
    }

    public float CalculateDamage(float attack, float stat)
    {
        return attack * stat; //TODO: Needs a major fucking overhaul
    }

}
