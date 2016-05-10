using UnityEngine;
using System.Collections;

public abstract class GenericProjectileCallerScript : MonoBehaviour {

    public GameObject towerSourceObject;

    // Use this for initialization
    void Start () {
	
	}

    public abstract float getDamage();

    public void addKillToTower()
    {
        towerSourceObject.GetComponent<GenericTower>().addKill();
    }
}
