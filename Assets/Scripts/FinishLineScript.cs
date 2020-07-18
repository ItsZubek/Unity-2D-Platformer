using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player Completed the level!");
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                FindObjectOfType<AudioManager>().Play("LevelComplete");
                SceneManager.LoadScene(0);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("LevelComplete");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //LOAD NEXT LEVEL
            }
        }
    }
}
