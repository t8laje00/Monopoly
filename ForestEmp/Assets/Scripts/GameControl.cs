using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    private static GameObject whoWinsTextShadow, player1MoveText, player2MoveText;

    private static GameObject player1, player2;
    public static GameControl instance;
    public float scrollSpeed = 1.5f;

    public static int diceSideThrown = 0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;

    public static bool gameOver = false;

    void Awake()
    {
        
        if (instance == null)
            
            instance = this;
        
        else if (instance != this)
            
            Destroy(gameObject);
    }

    void Start () {

        whoWinsTextShadow = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
        player1.GetComponent<Collider2D>().enabled = false;
        player2.GetComponent<Collider2D>().enabled = false;

    }

    void Update()
    {
        if (player1.GetComponent<FollowThePath>().waypointIndex > 
            player1StartWaypoint + diceSideThrown)
        {
            player1.GetComponent<FollowThePath>().moveAllowed = false;
        //    player1.GetComponent<Collider2D>().enabled = false; player2.GetComponent<Collider2D>().enabled = true;
            player1MoveText.gameObject.SetActive(false);
            player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex >
            player2StartWaypoint + diceSideThrown)
        {
            player2.GetComponent<FollowThePath>().moveAllowed = false;
         //   player1.GetComponent<Collider2D>().enabled = true; player2.GetComponent<Collider2D>().enabled = false;
            player2MoveText.gameObject.SetActive(false);
            player1MoveText.gameObject.SetActive(true);
            
            player2StartWaypoint = player2.GetComponent<FollowThePath>().waypointIndex - 1;
        }

        if (player1.GetComponent<FollowThePath>().waypointIndex == 
            player1.GetComponent<FollowThePath>().waypoints.Length)
        {
            player1.GetComponent<FollowThePath>().waypointIndex = 0;
        }

        if (player2.GetComponent<FollowThePath>().waypointIndex ==
            player2.GetComponent<FollowThePath>().waypoints.Length)
        {
            player1.GetComponent<FollowThePath>().waypointIndex = 0;
        }
    }

    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove) { 
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                player1.GetComponent<Collider2D>().enabled = true; player2.GetComponent<Collider2D>().enabled = false;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                player1.GetComponent<Collider2D>().enabled = false; player2.GetComponent<Collider2D>().enabled = true;
                break;
        }
    }
}
