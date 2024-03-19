using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public void GoToSelectScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToHelpScene()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToLevelOne()
    {
        ScoreManager.instance.score = 0;
        SceneManager.LoadScene(3);
    }

    public void GoToLevelTwo()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(3);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToEndless()
    {
        SceneManager.LoadScene(6);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
