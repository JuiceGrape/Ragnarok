using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Helm", menuName = "Objects/Equipment/Helm")]
public class HelmBase : EquipmentBase
{
    public override Enums.SlotType GetSlotType()
    {
        return Enums.SlotType.Head;
    }
}
