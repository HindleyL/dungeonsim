using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public int spawninc;
    public int spawnNum;
    public Transform target;
    public static int level;
    public static List<EnemyNavMovement> enemies = new List<EnemyNavMovement>();

    // Start is called before the first frame update
    void Start()
    {
        level = 0;
    }

    void FixedUpdate()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0)
        {
            Spawn();
        }
    }
    
    void Spawn()
    {
        for(int i=0;i<spawnNum;i++)
        {
            int num = Mathf.Min(i < 20 ? i > 5 ? 1 : 0 : Mathf.FloorToInt(i / 20.0f) + 1,SpawnObjects.Length - 1);
            //min picks the lowest of the two numbers, divide the spawn number by 20 and giving me the closest whole number and round down.
            GameObject enemy = Instantiate(SpawnObjects[num],target.position,Quaternion.identity);
            enemies.Add(enemy.GetComponent<EnemyNavMovement>());
        }
        spawnNum += spawninc;
        level++;
    }
}
