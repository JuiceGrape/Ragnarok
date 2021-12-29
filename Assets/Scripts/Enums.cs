using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum SlotType
    {
        Weapon,
        OffHand,
        Head,
        Chest,
        Legs,
        Boots,
        Invalid
    }
    
    public enum Rarity
    {
        Broken,
        Fixed,
        Improved,
        Unique
    }

    public enum Stat
    { 
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
    }

    public enum Element
    {
        Physical,
        Arcane,
        Light,
        Dark,
        Fire,
        Ice,
        Lightning,
        Poison,
        Acid
    }

    public enum InputState
    {
        Down,
        Up,
        Invalid
    }
}
