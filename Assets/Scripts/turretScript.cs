using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour
{
    public int health = 100;
   [SerializeField] private Transform firePoint;
    [SerializeField] private Transform bullet;
    public float TimerBetweenShots;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed > TimerBetweenShots)
        {
            Fire();
        }
        if(health <= 0)
        {
            Die();
        }
    }
    void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        timeElapsed = 0;
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Debug.Log("Turret HIT");
        }
    }
}
