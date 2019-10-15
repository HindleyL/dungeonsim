using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float nextTimeAttackIsAllowed = -1.0f;

    [SerializeField] float attackDelay = 1.0f;

    [SerializeField] int damageDealt = 5;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player"&& Time.time >= nextTimeAttackIsAllowed)
        {
            HealthScript playerHealth = other.GetComponent<HealthScript>();
            playerHealth.Damage(damageDealt);
            nextTimeAttackIsAllowed = Time.time + attackDelay;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
