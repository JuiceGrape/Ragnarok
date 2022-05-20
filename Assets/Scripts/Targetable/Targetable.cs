using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Targetable : MonoBehaviour
{
    public static Targetable CurrentTarget;

    private float OutlineWidth = 0.0f;

    private void Start()
    {
        OutlineWidth = GetComponent<Renderer>().material.GetFloat("_OutlineWidth");
        GetComponent<Renderer>().material.SetFloat("_OutlineWidth", 0.0f);
    }

    public void UnTarget()
    {
        GetComponent<Renderer>()?.material.SetFloat("_OutlineWidth", 0.0f);
    }

    public void Target()
    {
        GetComponent<Renderer>()?.material.SetFloat("_OutlineWidth", OutlineWidth);
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

    
