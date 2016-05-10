using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RockTower : GenericTower {


    void start()
    {

        reloadTime = 1f;
        turnSpeed = 5f;
        firePauseTime = .25f;
        // range set by size of collider. done in parent class.
        errorAmount = .005f;
    }


}
