using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            SaveTotalScore();
            Debug.Log("Save Score");
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
