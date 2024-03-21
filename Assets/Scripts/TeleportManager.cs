using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    public void GoToSelectScene()
    {
        SceneManager.LoadScene(1);
        PlayerController.canUseMove = false;
        ScoreManager.instance.score = 0;
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

    public void GoToLevelOneCutscene()
    {
        SceneManager.LoadScene(10);
    }

    public void GoToLevelTwo()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToLevelTwoCutscene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(11);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToEndless()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToEndless2P()
    {
        SceneManager.LoadScene(8);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
