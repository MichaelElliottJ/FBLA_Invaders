using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public void BuyOneLife()
    {
        if (ScoreManager.instance.score >= 1000)
        {
            PlayerHealth.health += 1;
            ScoreManager.instance.score -= 1000;
        }
    }

    public void FullLives()
    {
        if (ScoreManager.instance.score >= 1500)
        {
            PlayerHealth.health = 3;
            ScoreManager.instance.score -= 1500;
        }
    }

    public void Faster()
    {
        if (ScoreManager.instance.score >= 500)
        {
            PlayerController.speed += 0.5f;
            ScoreManager.instance.score -= 500;
        }
    }
}
