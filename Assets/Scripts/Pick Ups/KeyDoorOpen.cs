using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpen : MonoBehaviour
{
    [SerializeField] private GameObject DoorToOpen;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("KeyPickUp");
            DoorToOpen.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
