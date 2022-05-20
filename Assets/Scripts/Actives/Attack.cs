using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicAttack", menuName = "Objects/Active/BasicAttack")]
public class Attack : ScriptableObject
{
    public float Range = 0;

    public float AOE = 0;

    public float DamageModifierMin = 1;
    public float DamageModifierMax = 1;

    private float MeleeRange = 1.5f; //TODO: How do I do this in a better way?

    public void AttackHittable(Hittable hittable, float minDamage, float maxDamage)
    {

    }
}
