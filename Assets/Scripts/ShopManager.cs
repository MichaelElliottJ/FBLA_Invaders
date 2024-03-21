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
            Debug.Log(PlayerHealth.health);
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
        if (ScoreManager.instance.score >= 750)
        {
            PlayerController.firerate -= 0.05f;
            ScoreManager.instance.score -= 750;
        }
    }

    public void BuyUltimate()
    {
        if (ScoreManager.instance.score >= 2000)
        {
            PlayerController.moveUnlocked = true;
            ScoreManager.instance.score -= 2000;
        }
    }
}
