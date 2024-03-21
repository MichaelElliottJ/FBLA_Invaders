using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateIndicator : MonoBehaviour
{
    public SpriteRenderer sr;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.canUseMove)
        {
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        else
        {
            sr.material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        }
    }
}
