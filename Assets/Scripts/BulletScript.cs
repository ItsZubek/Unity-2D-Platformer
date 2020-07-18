using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float lifeTime;
    private GameObject player;
    Vector2 pos;
    Vector2 velocity;
    public int damage;

    private void Awake()
    {
        pos = transform.position; 
        Invoke("DestroyBullet", lifeTime);
        player = GameObject.Find("Player");
    }
    void Start()
    {
        
        if (player.transform.localScale.x < 0)
        {
            velocity = new Vector2(-speed*Time.deltaTime,0);
        }
        else
        {
            velocity = new Vector2(speed * Time.deltaTime, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
         pos += velocity;
        transform.position = pos;
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyScript>().Health -= damage;
            DestroyBullet();
        }
        else if(collision.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.GetComponent<BoxCollider2D>());
        }
        else if(collision.CompareTag("Grounded"))
        {
            DestroyBullet();
        }
        else if(collision.CompareTag("Wall"))
        {
            DestroyBullet();
        }
        else if (collision.CompareTag("Turret"))
        {
            collision.GetComponent<turretScript>().health -= damage;
            DestroyBullet();
        }

        Debug.Log("Bullet hit: " + collision.name);
    }
}
