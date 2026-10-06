using System.Collections.Generic;
using UnityEngine;

public class EnemyDataGiver : MonoBehaviour
{
    public static List<EntityController> entities;

    public static void AddSelfToEntities(EntityController ent)
    {
        foreach (EntityController item in entities)
        {
            if(item == ent) return;
        }
        entities.Add(ent);
    }

    public static EntityController GetLeader() //returns the highest scoring entity thats not themselves
    {
        EntityController highest = null; 
        foreach (EntityController item in entities)
        {
            if(highest == null) 
            {
                highest = item;
                continue;
            }
            if(item.score > highest.score)
            {
                highest = item;
                continue;
            }
        }
        return highest;
    }
    public static EntityController GetLeaderNotMe(EntityController me) //returns the highest scoring entity thats not themselves
    {
        EntityController highest = null; 
        foreach (EntityController item in entities)
        {
            if(highest == null) 
            {
                highest = item;
                continue;
            }
            if(item.score > highest.score && item != me)
            {
                highest = item;
                continue;
            }
        }
        return highest;
    }

    public static EntityController GetLowest()
    {
        EntityController lowest = null; 
        foreach (EntityController item in entities)
        {
            if(lowest == null) 
            {
                lowest = item;
                continue;
            }
            if(item.score < lowest.score)
            {
                lowest = item;
                continue;
            }
        }
        return lowest;
    }

    public static EntityController GetLowestNotMe(EntityController me)
    {
        EntityController lowest = null; 
        foreach (EntityController item in entities)
        {
            if(lowest == null) 
            {
                lowest = item;
                continue;
            }
            if(item.score < lowest.score && item != me)
            {
                lowest = item;
                continue;
            }
        }
        return lowest;
    }
    
}
