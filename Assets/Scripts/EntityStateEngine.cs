using Unity.VisualScripting;
using UnityEngine;

public class EntityStateEngine : MonoBehaviour
{
    public enum Emotions
    {
        Calm,
        Desperate,
        Angry
    }
    public enum States
    {
        Roaming,
        GoingToBerry,
        BringingBerryBack,
        Stunned,
        Combat
    }
    public enum DescisionStates
    {
        EntityHunting,
        BerryHunting,
        Hiding
    }
    private EntityController entity;

    void Start()
    {
        TryGetComponent<EntityController>(out entity);
        if(entity == null) Destroy(this);
    }
    public DescisionStates UpdateDescisionState()
    {
        float descision = 0;
      
        descision -= entity.score - EnemyDataGiver.GetLeaderNotMe(entity).score;       
        descision += entity.currentAngerLevel;

        if(descision < -3) return DescisionStates.Hiding;
        if(descision > 3) return DescisionStates.EntityHunting;
        return DescisionStates.BerryHunting;   
    }
    public Emotions UpdateEmotions()
    {
        if((entity.desperation < entity.patience) && 
        (entity.patience > entity.agression * entity.currentAngerLevel))
        {
            return Emotions.Calm;
        }
        else if (entity.desperation < 
        entity.agression * entity.currentAngerLevel)
        {
            return Emotions.Angry;
        }
        else return Emotions.Desperate;
    }

}
