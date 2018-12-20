using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testtp : MonoBehaviour {

    public GameObject Player1, Player2;
    public Transform Waypoint;

    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    private static GameObject player1MoveText, player2MoveText;
    public static int diceSideThrown = 0;

    // Use this for initialization
    void Start () {

        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");

        //move not allowed
        Player1.GetComponent<FollowThePath>().moveAllowed = false;
        Player2.GetComponent<FollowThePath>().moveAllowed = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "p1")
        {
            Player1.transform.position = Waypoint.transform.position;

        }

         if (collision.gameObject.tag == "p2")
        {
            Player2.transform.position = Waypoint.transform.position;
            
        }
    }
}
