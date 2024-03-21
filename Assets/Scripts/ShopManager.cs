using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public AudioSource buySound;
    public AudioSource cantBuySound;

    public void BuyOneLife()
    {
        if (ScoreManager.instance.score >= 1000)
        {
            PlayerHealth.health += 1;
            ScoreManager.instance.score -= 1000;
            buySound.Play();
        }
        else
        {
            cantBuySound.Play();
        }
    }

    public void FullLives()
    {
        if (ScoreManager.instance.score >= 1500)
        {
            PlayerHealth.health = 3;
            ScoreManager.instance.score -= 1500;
            buySound.Play();
        }
        else
        {
            cantBuySound.Play();
        }
    }

    public void Faster()
    {
        if (ScoreManager.instance.score >= 750)
        {
            PlayerController.firerate -= 0.05f;
            ScoreManager.instance.score -= 750;
            buySound.Play();
        }
        else
        {
            cantBuySound.Play();
        }
    }

    public void BuyUltimate()
    {
        if (ScoreManager.instance.score >= 2000)
        {
            PlayerController.moveUnlocked = true;
            ScoreManager.instance.score -= 2000;
            buySound.Play();
        }
        else
        {
            cantBuySound.Play();
        }
    }
}
