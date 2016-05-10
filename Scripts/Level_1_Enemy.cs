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
            // current implementation for generic damage getting. works so far.
            GenericProjectileCallerScript theScript = (GenericProjectileCallerScript)other.gameObject.GetComponent<GenericProjectileCallerScript>();
            hitPoints = hitPoints - theScript.getDamage();
            Destroy(other.gameObject);
            if (hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
