using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseManager : MonoBehaviour
{
    public TMP_Text score;

    private void Start()
    {
        score.text = ScoreManager.instance.score.ToString();
    }
}
