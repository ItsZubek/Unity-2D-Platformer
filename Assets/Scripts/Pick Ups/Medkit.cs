using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{

    [SerializeField] private HealthController controller;
    public int healthtoAdd;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            controller.playerHealth += healthtoAdd;

            if(controller.playerHealth > controller.maxHealth)
            {
                controller.playerHealth = controller.maxHealth;
            }
            controller.UpdateHealth();
            gameObject.SetActive(false);
        }
    }
}
