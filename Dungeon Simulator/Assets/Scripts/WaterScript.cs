using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour
{
    [SerializeField] int maximumWater = 100;
    int CurrentWater;
    bool inWater;
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
    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<WaterScript>().inWater = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<WaterScript>().inWater = false;
        }
    }

    public void WaterLoss(){
        if (!inWater)
        {
            CurrentWater -= 10;
            drown = 0;
        if(CurrentWater <= 0&&gameObject.tag=="Player")
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


