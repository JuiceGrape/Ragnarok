using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable : Targetable
{
    public override bool IsAttackable()
    {
        return true;
    }
}
