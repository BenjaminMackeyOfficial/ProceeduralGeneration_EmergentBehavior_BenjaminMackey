using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class EntityController : MonoBehaviour
{    
    //static alterations
    public string entityName;
    public float agression;
    public float speed;
    public float hitPower;
    public float hitSpeed;
    public float throwPower;
    public float patience;
    //

    //realTime changing values (effected by events)
    public int score;
    public int currentAngerLevel;
    public int desperation;
    //

    //for controllables
    public Berry currentBerryTarget;
    public EntityController playerTarget;
    //

    //referances
    private NavMeshAgent navMeshAgent;
    //

    //states
    
    private EntityStateEngine stateEngine;
    public EntityStateEngine.Emotions emotionalState; //modifier to descision making
    public EntityStateEngine.DescisionStates descisionState; //destinct strategies to win
    public EntityStateEngine.States state; //what the entity is currently doing
    //
    public int EventID {get; private set;}
    //

    public EntityController(string name, float agr, float spd, float hitPwr, float hitSpd, float thrwPwr, float patienc)
    {
        entityName = name;
        agression = agr;
        speed = spd;
        hitPower = hitPwr;
        hitSpeed = hitSpd;
        throwPower = thrwPwr;
        patience = patienc;
        Debug.Log("Welcome in, " + name + "!");
    }
    private Unity.Mathematics.Random rand;
    void Awake()
    {
        EventID = rand.NextInt(1,999999999);
    }

    void Start()
    {
        TryGetComponent<EntityStateEngine>(out stateEngine);
        if(stateEngine == null) stateEngine = gameObject.AddComponent<EntityStateEngine>();

        navMeshAgent = GetComponent<NavMeshAgent>();

        emotionalState = stateEngine.UpdateEmotions();
        descisionState = stateEngine.UpdateDescisionState();

        SetUpNavMeshAgent();
    }

    private void SetUpNavMeshAgent()
    {
        navMeshAgent.speed = speed;
        navMeshAgent.acceleration = speed;
    }
    void Update()
    {
        if(descisionState == EntityStateEngine.DescisionStates.BerryHunting)
        {
            if(currentBerryTarget == null)
            {
                if(emotionalState == EntityStateEngine.Emotions.Calm) currentBerryTarget = BerryInfoGiver.RequestSafeBerry();
                else currentBerryTarget = BerryInfoGiver.RequestClosesBerry();
            }
            navMeshAgent.SetDestination(currentBerryTarget.transform.position);
            return;
        }

        if(descisionState == EntityStateEngine.DescisionStates.EntityHunting)
        {
            if(playerTarget == null)
            {
                playerTarget = EnemyDataGiver.GetLeaderNotMe(this);
            }
            navMeshAgent.SetDestination(playerTarget.transform.position);
            return;
        }

        if(descisionState == EntityStateEngine.DescisionStates.Hiding)
        {
            
        }

    }

    private void GrabbedBerry()
    {
        
    }
}
