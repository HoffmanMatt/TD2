using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Player_Info : MonoBehaviour { 

    public int playerID;
    public string selectedRace;
    // move to team object
   // public int livesRemaining = 30;
    public PlayerManager playerManagerScript;
    public GameObject playerManagerObject;
    public GameObject playerUI;
    public Canvas towerInfoCanvas;

    List<GameObject> currentTowers = new List<GameObject>();
    List<GameObject> highlightSelectionList = new List<GameObject>();


    /// TOWER INFO PANEL SHORTCUTS //
    Text selectedTowerCount;
    ///////////////////////////

    /// SELECTED TOWERS FOR RACE
    GameObject tower1;
    /// </summary>

    ClickManager clickManager = new ClickManager();

    // Use this for initialization
    void Start () {
        playerID = GetInstanceID();
        playerManagerObject = GameObject.Find("PlayerManager");
        playerManagerScript = (PlayerManager) playerManagerObject.GetComponent("PlayerManager");

        // when this object is created, send this object to the manager so it can index it
        playerManagerScript.addPlayer(transform.gameObject);

        // attach this player_info object to the PlayerManager object.
        playerManagerScript.setChildRelationship(transform.gameObject);
        
        // race select
        selectTrads();

        // Remove the race selection UI
        GameObject raceSelectionObject = GameObject.Find("RaceSelection UI");
        Destroy(raceSelectionObject);

        // instantiate and set up the interface, and then attach it to this object
        generateUI();


        foreach (Transform t in playerUI.transform)
        {
            if (t.name == "TowerInfo UI")
            {
                towerInfoCanvas = t.GetComponent<Canvas>();
            }
        }

        setupTowerInfoPanelShortcuts();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetMouseButtonUp(0))
        {
            if (clickManager.DoubleClick())
            {
                clearCurrentSelectionListAndUnhighlightTowers();
                // select all towers on camera
                foreach (GameObject tower in currentTowers)
                {
                    if (tower.GetComponent<Renderer>().isVisible) {
                        highlightSelectionList.Add(tower);
                        tower.GetComponent<GenericTower>().highlightTower();
                    }
                }
            }
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Tower")
                {
                    // clear current selection
                    clearCurrentSelectionListAndUnhighlightTowers();

                    //highlight tower
                    //broken for more than 1 turret 
                    hitInfo.transform.gameObject.GetComponent<GenericTower>().highlightTower();

                    // add it to the list of current towers this player has selected
                    highlightSelectionList.Add(hitInfo.transform.gameObject);
                }

                else if (hitInfo.transform.gameObject.tag == "Creep")
                {
                    //ok 
                }

                else
                {
                    clearCurrentSelectionListAndUnhighlightTowers();
                }
            }

            else
            {
                // else if you click the interface window
                // else if you click the build window
                // else clear target
                clearCurrentSelectionListAndUnhighlightTowers();
            }
        }

        if (highlightSelectionList.Count > 0)
        {
            towerInfoCanvas.gameObject.SetActive(true);
            // set up "tower info" panel information
            if (highlightSelectionList.Count == 1)
            {
                selectedTowerCount.text = "1 Tower Selected";
            }
            else
            {
                selectedTowerCount.text = highlightSelectionList.Count + " Towers Selected";

            }
        }

        else
        {
            towerInfoCanvas.gameObject.SetActive(false);
        }
	}


    void setupTowerInfoPanelShortcuts()
    {
        foreach (Transform t in towerInfoCanvas.gameObject.transform)
        {
            if (t.name == "TowerInfo Panel") //TowersSelectedText
            {
                //this is all the components in the towerinfo panel
                foreach (Transform t_display in t)
                {
                    if (t_display.name == "TowersSelectedText")
                    {
                        selectedTowerCount = t_display.GetComponent<Text>();
                    }
                }
            }
        }
    }


    void clearCurrentSelectionListAndUnhighlightTowers()
    {
        foreach (GameObject highlightedTargets in highlightSelectionList)
        {
            //broken for more than 1 turret
            highlightedTargets.GetComponent<GenericTower>().clearHighlight();
        }

        // clear the player's list
        highlightSelectionList = new List<GameObject>();
    }


    void generateUI ()
    {
        playerUI = Instantiate(playerManagerScript.genericUI);
        playerUI.transform.parent = transform;
        playerUI.name = "PlayerUI";
    }


    void selectTrads()
    {
        selectedRace = "Trads";
              
        Trads_Race trads = playerManagerObject.GetComponent<Trads_Race>();
        tower1 = trads.tower1;
        // ..... cont
    }
}
