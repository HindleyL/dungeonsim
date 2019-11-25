using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnter : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<WaterScript>().inWater = true;
            Debug.Log("Enter water");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<WaterScript>().inWater = false;
            Debug.Log("Exit Water");
        }
    }
}
