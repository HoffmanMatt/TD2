using UnityEngine;
using System.Collections;

public class NavMeshAI : MonoBehaviour {

    public GameObject destination;
    public GameObject waypoint1;
    public float moveSpeed = 5f;
    public float turnSpeed = 10f;

    bool waypoint1Hit = false;

    private Vector3 localPosition;
    private NavMeshAgent nav;
    private Quaternion desiredRotation;

    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move() {
        //localPosition = transform.position;
        if (!waypoint1Hit) {
            destination = waypoint1;
            desiredRotation = Quaternion.LookRotation(destination.transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * turnSpeed);

            nav.SetDestination(destination.transform.position);
            transform.Translate(transform.forward * Time.deltaTime * moveSpeed);
        }
    }
}
