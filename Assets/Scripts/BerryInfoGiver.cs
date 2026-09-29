using UnityEngine;

public class Berry
{
    public GameObject obj;
    public GameObject currentOwner;
}
public class BerryInfoGiver : MonoBehaviour
{
    private Berry[] berries;

    private void SpawnBerries(int ammount)
    {
        
    }

    private Berry RequestClosesBerry()
    {
        return new Berry();
    }
    private Berry RequestSafeBerry()
    {
        
        return new Berry();
    }
    
}
