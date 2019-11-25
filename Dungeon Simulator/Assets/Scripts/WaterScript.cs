using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] int maximumWater = 100;
    int CurrentWater;
    public bool inWater = false;
    int drown;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWater = maximumWater;
        InvokeRepeating("WaterLoss",0,2);
    }
    public bool NoWater { get { return CurrentWater <= 0; } }

    public int getWater()
    {
        return CurrentWater;
    }

    public int getMaxWater()
    {
        return maximumWater;
    }

    public void WaterLoss()
    {
        if (!inWater)
        {
            CurrentWater -= 10;
            Debug.Log(drown);
            drown = 0;
            if(NoWater &&gameObject.tag=="Player")
            {
                gameObject.GetComponent<HealthScript>().Damage(5);
                Debug.Log("LoseHealth");
            }
        }
        else
        {
            CurrentWater += 15;
            drown++;
            if(drown >5)
            {
                gameObject.GetComponent<HealthScript>().Damage(5);
                Debug.Log(123);
            }
        }
        if (CurrentWater <= 0)
        {
            CurrentWater = 0;
        }
        if (CurrentWater >=100)
        {
            CurrentWater = 100;
        }
    }
}


