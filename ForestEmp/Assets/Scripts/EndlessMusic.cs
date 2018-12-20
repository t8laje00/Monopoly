using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessMusic : MonoBehaviour
{

    private void Start()
    {
        
    }

    private static EndlessMusic instance = null;
    public static EndlessMusic Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        
    }

}
