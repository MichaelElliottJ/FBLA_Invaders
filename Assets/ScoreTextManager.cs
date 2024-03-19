using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTextManager : MonoBehaviour
{
    public TMP_Text scoreText;

    void Update()
    {
        scoreText.text = "SCORE: " + ScoreManager.instance.score;
    }
}
