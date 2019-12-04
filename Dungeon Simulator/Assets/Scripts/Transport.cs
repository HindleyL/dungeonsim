using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    public Transform waypoint;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            if(Time.time > other.GetComponent<HealthScript>().nextMove)
            {
                other.GetComponent<HealthScript>().nextMove = Time.time + 5.0f;
                
                other.GetComponent<CharacterController>().enabled = false;
                
                bool didDestroy = false;
                //turn off nav mesh agent before teleport
                if(other.GetComponent<UnityEngine.AI.NavMeshAgent>()){
                    other.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
                    didDestroy = true;
                }
                //teleports objects
                other.gameObject.transform.position = waypoint.position;
                //turn nav mesh back on after teleport
                if(didDestroy)
                {
                    other.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                }
                other.GetComponent<CharacterController>().enabled = true;

                if (other.gameObject.tag == "Player")
                {
                    foreach(EnemyNavMovement enemy in Spawning.enemies)
                    {
                        enemy.target.Add(transform);
                    }
                }
                else
                {
                    other.GetComponent<EnemyNavMovement>().target.Remove(transform);
                }
            }
        }
    } 
}
