using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    private GameObject controller;
    [SerializeField] private float speed;
    Vector2 pos;
    Vector2 velocity;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("HealthController");
        if (controller == null) Debug.LogError("COULDNT FIND HEALTHCONTROLLER");
        pos = transform.position;

        if (transform.localScale.x < 0)
        {
            velocity = new Vector2(-speed * Time.deltaTime, 0);
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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            controller.GetComponent<HealthController>().playerHealth-= damage;
            controller.GetComponent<HealthController>().UpdateHealth();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Turret"))
        {
            Physics2D.IgnoreCollision(transform.GetComponent<BoxCollider2D>(), collision.GetComponent<BoxCollider2D>());
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("Laser hit: " + collision.name);
    }
}
