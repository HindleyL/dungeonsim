using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        //print("pick up");
        HealthScript health = collider.GetComponent<HealthScript>();
        if (health != null&&collider.tag=="Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
            health.Damage(-50);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
