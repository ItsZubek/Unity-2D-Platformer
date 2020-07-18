using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    [SerializeField] private GameObject[] weapons;
    public int AmmoToAdd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if(weapons[i].activeSelf == true)
                {
                    weapons[i].GetComponent<Weapon>().max_ammo += AmmoToAdd;
                }
            }
            gameObject.SetActive(false);
        }
    }
}
