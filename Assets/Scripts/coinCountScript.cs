using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinCountScript : MonoBehaviour
{
    public int coins = 0;
    public Text CoinCounterTextOBJ;

    // Update is called once per frame
    void Update()
    {
        CoinCounterTextOBJ.text = coins.ToString("0");
    }
}
