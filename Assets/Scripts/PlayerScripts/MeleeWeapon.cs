using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeapon : MonoBehaviour
{
    private float timebetweenAttacks;
    public float startTimebetweenAttacks;

    public Transform AttackPosition;
    public float attackRange;
    public LayerMask enemylayer;
    public int damage;
    public Text ammoCounterDisplay;
    public Text AmmoTextDisplay;

    // Update is called once per frame
    void Update()
    {
        if(timebetweenAttacks <= 0)
        {
            Debug.Log("Melee attack is ready!");
            if(Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<AudioManager>().Play("Knife");
                Debug.Log("Pressed LMB!");
                Collider2D[] enemiesinRange = Physics2D.OverlapCircleAll(AttackPosition.position, attackRange, enemylayer);
                for (int i = 0; i < enemiesinRange.Length; i++)
                {
                    enemiesinRange[i].GetComponent<EnemyScript>().Health -= damage;
                    Debug.Log("DECREASING ENEMY HEALTH");
                }
            }
        }
        DisplayText();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPosition.position, attackRange);
    }
    void DisplayText()
    {
        AmmoTextDisplay.enabled = false;
        ammoCounterDisplay.text = " ";
    }
}
