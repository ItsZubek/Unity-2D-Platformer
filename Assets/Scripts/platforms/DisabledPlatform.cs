using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabledPlatform : MonoBehaviour
{
    public int seconds = 5;
    // Start is called before the first frame update

    // Update is called once per frame
    void Awake()
    {
        StartCoroutine(Appearance());
    }
    IEnumerator Appearance()
    {
        while (true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(seconds);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(seconds);
        }
    }
}
