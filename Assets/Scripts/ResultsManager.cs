using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour
{
    public GameObject results;

    public AudioSource celebrationSound;

    private void Update()
    {
        this.transform.position += Vector3.down * 2.0f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            celebrationSound.Play();
            Time.timeScale = 0.0f;
            results.SetActive(true);
        }
    }
}
