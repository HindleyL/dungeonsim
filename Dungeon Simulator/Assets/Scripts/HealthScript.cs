using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    int currentHealth = 0;
    public GameObject losePanel;
    public GameObject healthPickup;
    public float nextMove;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
                if (gameObject.tag != "Player")
                {
                    UIScript.updateScore(50);
                    Spawning.enemies.Remove(gameObject.GetComponent<EnemyNavMovement>());
                    Destroy(gameObject);
                    int num = Random.Range (0,20);
                    if (num == 13)
                    {
                        Instantiate(healthPickup,transform.position,Quaternion.identity);
                    }
                }
                else
                {
                    Cursor.visible = true;
                    losePanel.SetActive(true);
                    Time.timeScale = 0;
                }

        }
        else if (currentHealth >=100)
        {
            currentHealth = 100;
        }
    }
}
