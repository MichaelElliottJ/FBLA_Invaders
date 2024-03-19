using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("DestroyThis");
    }

    IEnumerator DestroyThis()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this);
    }
}
