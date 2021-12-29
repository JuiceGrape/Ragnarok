using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Equipment
{
    public Active Active { get; private set; }
    private HashSet<Passive> passives;
    public Enums.SlotType SlotType { get; private set; }

    public Equipment(EquipmentBase objBase, Enums.Rarity rarity)
    {
        InitializeActive(objBase); 
        InitializePassives(objBase, Random.Range(0 + (int)rarity, 2 + (int)rarity));
        InitializeStats(objBase, rarity); //TODO: Rarity multipliers to different functions for better parted behaviour?
    }

    public Equipment(EquipmentBase objBase) //Starting gear, no passives or actives
    {

    }
    
    private void InitializeActive(EquipmentBase objBase) //TODO: Add proper chances based on rarity
    {
        Active = objBase.Actives[Random.Range(0, objBase.Actives.Count)];
    }

    private void InitializePassives(EquipmentBase objBase, int amountOfPassives)
    {
        HashSet<int> excludePassives = new HashSet<int>();

        for (int i = 0; i < amountOfPassives; i++)
        {
            int passiveIndex = NumberInRangeWithExclusion(0, objBase.Passives.Count, excludePassives);

            if (excludePassives.Contains(passiveIndex))
            {
                //should not happen, can happen in case the amount of possible passives is less than what we're trying to give, in which case we want to stop this function
                return;
            }

            excludePassives.Add(passiveIndex);
            passives.Add(objBase.Passives[passiveIndex]);
        }
    }

    private void InitializeStats(EquipmentBase objBase, Enums.Rarity rarity)
    {

    }

    public IEnumerable<Passive> GetPassives()
    {
        return passives;
    }

    public static int NumberInRangeWithExclusion(int min, int max, HashSet<int> exclude)
    {
        var range = Enumerable.Range(min, max - min).Where(i => !exclude.Contains(i));

        if (range.Count() == 0)
        {
            return min;
        }

        int index = Random.Range(0, range.Count());
        return range.ElementAt(index);
    }
}
