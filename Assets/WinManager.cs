using UnityEngine;
using TMPro;

public class WinManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
    }
}
