using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targetable : MonoBehaviour
{
    public static Targetable CurrentTarget;

    public void UnTarget()
    {
        GetComponent<Renderer>()?.material.SetFloat("_OutlineEnabled", 0);
    }

    public void Target()
    {
        GetComponent<Renderer>()?.material.SetFloat("_OutlineEnabled", 1);
    }

    private void OnMouseOver()
    {
        if (CurrentTarget != null)
        {
            CurrentTarget.UnTarget();
        }

        CurrentTarget = this;
        Target();
    }

    private void OnMouseExit()
    {
        if (CurrentTarget == this)
        {
            UnTarget();
            CurrentTarget = null;
        }
    }

    public abstract bool IsAttackable();
}

    
