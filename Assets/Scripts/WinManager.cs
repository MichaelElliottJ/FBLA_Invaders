using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public GameObject newBest;

    private void Start()
    {
        ScoreManager.instance.score += 10000;

        if (ScoreManager.instance.score >= ScoreManager.instance.bestScore)
        {
            ScoreManager.instance.bestScore = ScoreManager.instance.score;
            newBest.SetActive(true);
        }
        else
        {
            newBest.SetActive(true);
        }

        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
