using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public GameObject genericPlayer;
    public GameObject genericUI;

    public GameObject player1;
    public bool player1Active = false;
    public int player1ID;
    public GameObject player2;
    public bool player2Active = false;
    public GameObject player3;
    public bool player3Active = false;
    public GameObject player4;
    public bool player4Active = false;
    public GameObject player5;
    public bool player5Active = false;
    public GameObject player6;
    public bool player6Active = false;

    public bool is1v1 = false;
    public bool is2v2 = false;
    public bool is3v3 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void initializePlayer ()
    {
        Instantiate(genericPlayer);

        // not sure if needed. idk heh
        //Destroy(GameObject.Find("Trads Race"));
    }

    
    public void addPlayer (GameObject player)
    {
        if (!player1Active)
        {
            player1Active = true;
            player1 = player;
            player1ID = player.GetInstanceID();
            player.name = "player1";
        }
    }


    public void setChildRelationship (GameObject player)
    {
        player1ID = player.GetInstanceID();
        player.transform.parent = transform;
    }
    
}

/*  NOTES:
 *  - Restructure grid after building removal
 * 
 * 
 * */
