using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower_Rocket_Launcher : MonoBehaviour {

    public GameObject myProjectile;
    float reloadTime = 1f;
    float turnSpeed = 5f;
    float firePauseTime = .25f;
    public float range;
    //var muzzleEffect : GameObject;
    float errorAmount = .001f;
    public GameObject myTarget;
    public Transform muzzlePositions;
    public Transform turretRotator;
    //public ArrayList enemies = new ArrayList();
    Dictionary<int, GameObject> enemyDictionary = new Dictionary<int, GameObject>();
    //List<GameObject> enemiesInRange = new List<GameObject>();
    //LinkedList<int> enemyIDs = new LinkedList<int>(); 

    private float nextFireTime;
    private float nextMoveTime;
    private Quaternion desiredRotation;
    private float aimError;


    bool enemiesInRange;

    void Start()
    {
        SphereCollider sphereColl = transform.GetComponent<SphereCollider>();
        range = sphereColl.radius;
    }
    
    void Update()
    {
        if (myTarget)
        {
            if (Time.time >= nextMoveTime) {
            CalculateAimPosition(myTarget.transform.position);
            turretRotator.rotation = Quaternion.Lerp(turretRotator.rotation, desiredRotation, Time.deltaTime * turnSpeed);
            }

            if (Time.time >= nextFireTime)
            {
                FireProjectile();
                enemiesInRange = true;
            }
        }

        else if (enemiesInRange)
        {
            bool hasNewTarget = hasEnemiesInRangeAndSetIfSo();
            if (!hasNewTarget)
            {
                myTarget = null;
                enemiesInRange = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (myTarget == null) 
        {
            if (other.gameObject.tag == "Creep")
            {
                nextFireTime = Time.time + (reloadTime * .5f);
                myTarget = other.gameObject;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Creep")
        {
            if (other.gameObject.GetInstanceID() == myTarget.GetInstanceID())
            {
                if (hasEnemiesInRangeAndSetIfSo())
                { }

                else
                {
                    myTarget = null;
                }
            }
        }
    }


    bool hasEnemiesInRangeAndSetIfSo()
    {
        List<GameObject> enemyObjects = new List<GameObject>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, range);
        if (colliders.Length == 0)
        {
            return false;
        }

        //now we need to use another array and put all enemies in it, so that it doesnt include ground and other towers and stuff      
        else
        {
            foreach (Collider collid in colliders)
            {
                if (collid.gameObject.tag == "Creep")
                {
                    enemyObjects.Add(collid.gameObject);
                }
            }
        }

        if (enemyObjects.Count > 0)
        {
            myTarget = enemyObjects[0];
        }
        return true;
    }


    GameObject getNextEnemyObject () {
       foreach (KeyValuePair<int, GameObject> entry in enemyDictionary)
       {
            return entry.Value;
       }
       return null;           
    }

    void CalculateAimPosition(Vector3 targetPos)
    {
        //Vector3 aimPoint = new Vector3 (targetPos.x + aimError, targetPos.y + aimError, targetPos.z + aimError) - transform.position;   
        Vector3 aimPoint = new Vector3(targetPos.x + aimError, targetPos.y + aimError, targetPos.z + aimError) - muzzlePositions.position;
        desiredRotation = Quaternion.LookRotation(aimPoint);
    }


    void CalculateAimError()
    {
        aimError = Random.Range(-errorAmount, errorAmount);
    }

    void FireProjectile()
    {
        //audio.Play();
        nextFireTime = Time.time + reloadTime;
        nextMoveTime = Time.time+firePauseTime;
        CalculateAimError();
        Instantiate(myProjectile, muzzlePositions.position, muzzlePositions.rotation);
    }
    
}
