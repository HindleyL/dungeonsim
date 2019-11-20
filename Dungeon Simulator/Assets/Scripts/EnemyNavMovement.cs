using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public List <Transform> target = new List <Transform>();
    // Start is called before the first frame update
    void Start()
    {
        target.Add (GameObject.FindGameObjectWithTag("Player").transform);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    { 
        agent.SetDestination(target[target.Count -1].position);
            
        transform.LookAt(target[target.Count -1].transform);
        Vector3 ang=transform.eulerAngles;
        transform.eulerAngles = new Vector3(0,ang.y,0);
    }
}
