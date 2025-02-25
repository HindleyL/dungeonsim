﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    public HealthScript healthScript;
    public WaterScript waterScript;
    public TMP_Text healthTxt;
    public Slider healthBar;
    public TMP_Text waterTxt;
    public Slider waterBar;
    float lastHP;
    public TMP_Text scoreNum;
    public TMP_Text timeNum;
    public static int score;
    public GameObject losePanel;
    public Text levelTxt;

    // Start is called before the first frame update
    void Start()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum = manager.score;
        timeNum = manager.timeTxt;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        lastHP = healthScript.getHealth();
        waterBar.maxValue = waterScript.getMaxWater();
        waterBar.value = waterScript.getWater();
        waterTxt.text = "Water Level: " + waterScript.getWater();
    }

    public static void updateScore(int amount)
    {
        score += amount;
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";
        levelTxt.text = "Level : " + Spawning.level;
        waterBar.value = waterScript.getWater();
        waterTxt.text = "Water Level: " + waterScript.getWater();
    }

    IEnumerator updateUI()
    {
        lastHP = Mathf.Lerp(lastHP, healthScript.getHealth(),0.1f);
        healthBar.value = lastHP;
        healthTxt.text = "Health: " + healthScript.getHealth();
        timeNum.text = "" + (int)Time.time;
        scoreNum.text = score + "";

        if (healthScript.IsDead)
        {
            losePanel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine("updateUI");
    }
}
