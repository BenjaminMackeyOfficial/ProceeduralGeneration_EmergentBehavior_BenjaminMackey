using UnityEngine;
using UnityEngine.AI;

public class EntityController : MonoBehaviour
{    
    //static alterations
    private string entityName;
    private float agression;
    private float speed;
    private float hitPower;
    private float hitSpeed;
    private float throwPower;
    private float patience;
    //

    //realTime changing values (effected by events)
    public int score;
    private int currentAngerLevel;
    private int desperation;
    //

    //for controllables
    private Berry currentBerryTarget;
    private EntityController playerTarget;
    //

    //referances
    private NavMeshAgent navMeshAgent;
    //

    //states
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

    public Emotions emotionalState; //modifier to descision making
    public DescisionStates descisionState; //destinct strategies to win
    public States state; //what the entity is currently doing
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
        Debug.Log("Welcome in, " + name);
    }

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }
}
