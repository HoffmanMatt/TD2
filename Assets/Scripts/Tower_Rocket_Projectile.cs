using UnityEngine;
using System.Collections;

public class Tower_Rocket_Projectile : MonoBehaviour {

    public float damagePerAttack;

    float projectileSpeed = 10;
    float maxRange = 15;
    float baseDamage = 17;

    private float distanceTraveled;

    void Start()
    {
        damagePerAttack = baseDamage;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
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
