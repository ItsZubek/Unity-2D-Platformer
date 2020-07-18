using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeScript : MonoBehaviour
{
    [SerializeField] private HealthController controller;
    private Rigidbody2D playerrb;
    public int damage = 25;
    Vector2 launchVector;
    public float LaunchForce = 300;

    private void Start()
    {
        playerrb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        launchVector = new Vector2(0.0f, LaunchForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            controller.playerHealth -= damage;
            controller.UpdateHealth();
            playerrb.velocity = Vector2.up * LaunchForce;
        }
    }
}
