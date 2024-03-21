using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOneManager : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;

    void Start()
    {
        Instantiate(bullet1, transform.position, Quaternion.identity);
        Instantiate(bullet2, transform.position, Quaternion.identity);
        Instantiate(bullet3, transform.position, Quaternion.identity);
        Instantiate(bullet4, transform.position, Quaternion.identity);
        Instantiate(bullet5, transform.position, Quaternion.identity);
    }
}
