using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Targetable
{
    public override bool IsAttackable()
    {
        return false;
    }
}
