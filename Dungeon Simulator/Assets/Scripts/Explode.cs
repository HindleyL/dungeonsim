using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float timeToExplode = 5f;
    public float damageRange = 5f;
    public int damage = 20;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DamageGrenade",timeToExplode);
    }

    // Update is called once per frame
    void DamageGrenade()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            //check enemy in range
            if (Vector3.Distance(transform.position,enemy.transform.position)<damageRange)
            {
                //damage enemy if in range
                enemy.GetComponent<HealthScript>().Damage(damage);
            }
        }
        Destroy(gameObject);
    }
}
