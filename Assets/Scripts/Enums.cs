﻿using System.Collections;
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

    public static float GetMultiplierFromRarity(Rarity rarity)
    {
        switch(rarity)
        {
            case Rarity.Broken:
                return 0.5f;
            case Rarity.Fixed:
                return 0.75f;
            case Rarity.Improved:
            case Rarity.Unique:
                return 1.0f;
            default:
                return 0.0f;
        }
    }

    public enum Direction
    {
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }
}
