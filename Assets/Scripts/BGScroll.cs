using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float speed = 4f;
    private Vector3 StartPosition;

    void Start()
    {
        StartPosition = transform.position;
    }


    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10.44237)
        {
            transform.position = StartPosition;
        }
    }
}
