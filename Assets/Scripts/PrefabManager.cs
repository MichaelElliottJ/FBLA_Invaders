using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public GameObject explosionOBJ;

    private static PrefabManager m_instance = null;
    public static PrefabManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (PrefabManager)FindObjectOfType(typeof(PrefabManager));
            }
            return m_instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
