using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    [SerializeField] private Text Healthtext;
    public int maxHealth;

     public void UpdateHealth()
    {
        Healthtext.text = playerHealth.ToString("0");
    }

}
