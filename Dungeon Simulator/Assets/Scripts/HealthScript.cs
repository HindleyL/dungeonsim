using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int maximumHealth = 100;
    int currentHealth = 0;
    public GameObject losePanel;
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
            if (gameObject.tag != "Player")
            {
            UIScript.updateScore(50);
            Destroy(gameObject);
            }
            else
            {
                Cursor.visible = true;
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }

        }
    }
}
