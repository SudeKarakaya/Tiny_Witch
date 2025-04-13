using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

}
