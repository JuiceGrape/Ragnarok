using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Attack unarmedAttack;

    private Dictionary<Enums.SlotType, Equipment> equippedItems;

    public Attack EquippedAttack { get; private set; }


    private void Start()
    {
        equippedItems = new Dictionary<Enums.SlotType, Equipment>();

        if (unarmedAttack != null)
        {
            EquippedAttack = unarmedAttack;
        }
    }

    private bool EquipItem(Enums.SlotType slot, Equipment equipment)
    {
        if (GetEquipmentInSlot(slot) != null)
        {
            return false;
        }    

        if (equipment is Weapon)
        {
            if (slot == Enums.SlotType.Weapon)
            {
                var weapon = equipment as Weapon;
                EquippedAttack = weapon.Attack;
            }
            else
            {
                return false;
            }
        }

        equippedItems[slot] = equipment;
        return true;
    }

    private Equipment RemoveItem(Enums.SlotType slot)
    {
        var equipment = GetEquipmentInSlot(slot);

        if (equipment != null)
        {
            if (slot == Enums.SlotType.Weapon)
            {
                EquippedAttack = unarmedAttack;
            }
            equippedItems.Remove(slot);
        }

        return equipment;
    }

    public Weapon GetEquippedWeapon()
    {
        if (equippedItems.TryGetValue(Enums.SlotType.Weapon, out Equipment weapon))
        {
            return weapon as Weapon;
        }

        return null;
    }

    public Equipment GetEquipmentInSlot(Enums.SlotType slot)
    {
        if (equippedItems.TryGetValue(slot, out Equipment equipment))
        {
            return equipment;
        }

        return null;
    }

    public void Attack(Hittable target)
    {
        EquippedAttack.AttackHittable(target);
    }

    public void Interact(Interactable target)
    {
        Debug.Log(target.ToString() + "Is getting touched OwO");
    }
}
