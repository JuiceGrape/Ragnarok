using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class EquipmentBase : ScriptableObject
{
    public bool UsesBasicPassives = true;
    public List<Passive> Passives;

    public bool UsesBasicActives = true;
    public List<Active> Actives;

    public abstract Enums.SlotType GetSlotType();

    public IEnumerable<Passive> GetPossiblePassives()
    {
        foreach(Passive passive in Passives) { yield return passive; }

        //TODO: Use basic passives list
        if (UsesBasicPassives)
        {

        }
    }

    public IEnumerable<Active> GetPossibleActives()
    {
        foreach (Active active in Actives) { yield return active; }

        //TODO: Use basic actives list
        if (UsesBasicActives)
        {

        }
    }
}
