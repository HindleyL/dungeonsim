using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class MenuScript : MonoBehaviour
{
    
    UnityEvent gameStartEvent = new UnityEvent();

    void OnGameStart()
    {
        UIScript.score = 0;
    }
    
    void Start ()
    {
        gameStartEvent.AddListener(OnGameStart);
    }
    public void loadMain()
    {
        gameStartEvent.Invoke();
        SceneManager.LoadScene(2);
    }
    public void loadHelp()
    {
        SceneManager.LoadScene(1);
    }
        public void loadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    public void exitGame()
    {
        Application.Quit();
    }
}
