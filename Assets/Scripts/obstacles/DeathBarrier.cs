using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    [SerializeField] private HealthController controller;
    public int damage = 9999999;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            controller.playerHealth -= damage;
            controller.UpdateHealth();
        }
    }
}
