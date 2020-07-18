using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    private float timebetweenshots;
    public float starttimebetweenshots;
    public int max_ammo = 10;
    public int mag_capacity = 5;
    public int current_mag_capacity = 5;
    public GameObject bullet;
    public Transform FirePoint;
    public ParticleSystem muzzleflash;

    public Text ammoCounterDisplay;
    public Text AmmoTextDisplay;
    public Transform weapon;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Unspawn();
        }
    }
    private void Update()
    {

        if (timebetweenshots <= 0)
        {
            if (current_mag_capacity > 0)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    muzzleflash.Play();
                    Instantiate(bullet, FirePoint.position, transform.rotation);
                    current_mag_capacity--;
                    Debug.Log("Shot fired from: " + gameObject.name + " ammo in mag  " + current_mag_capacity);
                    timebetweenshots = starttimebetweenshots;
                }
            }
            else if (current_mag_capacity == 0)
            {
                if (max_ammo > 0)
                {
                    StartCoroutine(Reload());
                }
                else
                {
                    Debug.Log("No more ammo available");
                }

            }

            if (Input.GetKeyDown(KeyCode.R) && max_ammo > 0)
            {
                StartCoroutine(Reload());
                Debug.Log("Called reload");
            }
        }
        else
        {
            timebetweenshots -= Time.deltaTime;
        }

        DisplayText();
        
    }
    public void Unspawn()
    {
        Destroy(gameObject);
    }
    IEnumerator Reload()
    {
            if (current_mag_capacity < mag_capacity)
            {
                Debug.Log("Reloading");
            FindObjectOfType<AudioManager>().Play("Reload");
            yield return new WaitForSeconds(1);

                max_ammo -=(mag_capacity - current_mag_capacity);
                current_mag_capacity = mag_capacity;
                Debug.Log("Reloaded");

            if (current_mag_capacity < max_ammo && max_ammo < mag_capacity)
            {
                current_mag_capacity += max_ammo;
                max_ammo = 0;
            }

            }
        
    }
    void DisplayText()
    {
            AmmoTextDisplay.enabled = true;
            ammoCounterDisplay.text = current_mag_capacity.ToString() + "/" + max_ammo.ToString();

    }
}
