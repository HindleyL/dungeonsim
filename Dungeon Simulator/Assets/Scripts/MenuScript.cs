using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadMain()
    {
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
