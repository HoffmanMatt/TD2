﻿using UnityEngine;
using System.Collections;

public class Tower_Rocket_Projectile_Yaxis : MonoBehaviour {

    public float damagePerAttack;

    public float projectileSpeed = 25;
    public float maxRange = 16;
    public float baseDamage = 17;

    private float distanceTraveled;


    // Use this for initialization
    void Start() {
        damagePerAttack = baseDamage;
    }


    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.up * Time.deltaTime * projectileSpeed);
        //transform.position += Vector3.forward * Time.deltaTime * projectileSpeed;  
        distanceTraveled += Time.deltaTime * projectileSpeed;
        if (distanceTraveled >= maxRange)
        {
            Destroy(gameObject);
        }
    }


    public float getDamagePerAttack()
    {
        return damagePerAttack;
    }
}