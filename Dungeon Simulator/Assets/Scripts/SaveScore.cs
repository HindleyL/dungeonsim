using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveScore : MonoBehaviour
{
    public Transform player;
    public bool loadBank;
    public float distance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {               
        if (Input.GetKeyDown(KeyCode.F)&&(Vector3.Distance(transform.position,player.position))<distance)
        {
                    if (loadBank)
                    {
                        UIScript.score = GetTotalScore();
                        Debug.Log("Load Score");
                    }
                    else 
                    {
                        SaveTotalScore();
                        Debug.Log("Save Score");
                    }
                }
        }

    private void SaveTotalScore()
    {        
        PlayerPrefs.SetInt("totalScore", UIScript.score);
    }
        public int GetTotalScore()
    {
        return PlayerPrefs.GetInt("totalScore");
    }
}
