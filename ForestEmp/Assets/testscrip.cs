using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscrip : MonoBehaviour {

    public GameObject Panel;

	// Use this for initialization
	void Start () {
        Panel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "b")
        {
            //Destroy(collision.gameObject);
            Panel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "b")
        {
            Panel.SetActive(false);
        }
    }
}
