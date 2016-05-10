using UnityEngine;
using System.Collections;

public class Level_1_Enemy : MonoBehaviour {

    //float maxHitPoints = 50;
    public float hitPoints = 50;
    

    void Start()
    {      

    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Damage")
        {
            bool destroyThis = false;
            // current implementation for generic damage getting. works so far.
            GenericProjectileCallerScript theScript = other.gameObject.GetComponent<GenericProjectileCallerScript>();
            hitPoints = hitPoints - theScript.getDamage();
            
            if (hitPoints <= 0)
            {
                destroyThis = true;
                theScript.addKillToTower();
            }

            Destroy(other.gameObject);

            if (destroyThis)
            {
                Destroy(gameObject);
            }
        }
    }
}
