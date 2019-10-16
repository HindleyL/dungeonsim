using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMovement : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        {
            transform.LookAt(target.transform);
            Vector3 ang=transform.eulerAngles;
            transform.eulerAngles = new Vector3(0,ang.y,0);
        }
    }
}
