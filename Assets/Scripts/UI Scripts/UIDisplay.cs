using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    public GameObject[] weapons;
    public Text ammoDisplay;
    public Text Ammo;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if(weapons[i].activeSelf == true)
            {
                Ammo.enabled = true;
                Debug.Log("Ammo text false");
                ammoDisplay.enabled = true;
            }
            else
            {
                Ammo.enabled = false;
                ammoDisplay.enabled = false;
            }
        }
    }
}
