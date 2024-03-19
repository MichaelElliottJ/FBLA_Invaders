using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("DeleteGameObj");
    }
    
    IEnumerator DeleteGameObj()
    {
        yield return new WaitForSeconds(1);
        Destroy(this);
    }
}
