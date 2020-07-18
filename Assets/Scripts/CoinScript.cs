using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public GameObject coinUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.CompareTag("Player"))
        {
            coinUI.GetComponent<coinCountScript>().coins += 1;
            gameObject.SetActive(false);
        }
            
    }

}
