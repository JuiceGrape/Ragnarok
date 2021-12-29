using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boots", menuName = "Objects/Equipment/Boots")]
public class BootsBase : EquipmentBase
{
    public override Enums.SlotType GetSlotType()
    {
        return Enums.SlotType.Boots;
    }
}
