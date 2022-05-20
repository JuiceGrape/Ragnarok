using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics
{
    private Character player;

    public Dictionary<Enums.Stat, Resource> Attributes;
    public Statistics(Character character)
    {
        player = character;
        Attributes = new Dictionary<Enums.Stat, Resource>();

        foreach (var v in (Enums.Stat[])System.Enum.GetValues(typeof(Enums.Stat)))
        {
            var resource = AddResource(v.ToString(), 0, 50000, 5);
            Attributes.Add(v, resource);
        }
    }

    public void Reset()
    {

    }

    public Resource AddResource(string name, float min, float max, float val)
    {
        var child = new GameObject();
        child.transform.parent = player.gameObject.transform;
        var resource = child.gameObject.AddComponent<Resource>();

        resource.name = name;
        resource.minValue = min;
        resource.maxValue = max;
        resource.startValue = 5;

        return resource;
    }
}
