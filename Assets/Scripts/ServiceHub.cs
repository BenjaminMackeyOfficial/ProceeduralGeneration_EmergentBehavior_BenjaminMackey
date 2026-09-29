using Unity.VisualScripting;
using UnityEngine;

public class ServiceHub : MonoBehaviour
{
    public static ServiceHub Instance {get 
        {
            if(instace = null) 
            {
                Debug.Log("No serice hub! Uh oh!");
                return null;
            }
            return instace;
        }
    }
    private static ServiceHub instace;

    public BerryInfoGiver berryInfoGiver;

    void Awake()
    {
        if(instace == null)instace = this;
        else Destroy(this);
    }

}
