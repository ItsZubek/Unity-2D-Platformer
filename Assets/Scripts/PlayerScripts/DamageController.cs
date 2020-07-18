using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private HealthController controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Damage(damage);
        }
    }
    public void Damage(int damage)
    {
        controller.playerHealth -= damage;
        controller.UpdateHealth();
        gameObject.SetActive(false);
    }
}
