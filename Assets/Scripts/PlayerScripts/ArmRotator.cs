using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    public GameObject myPlayer;



    // Update is called once per frame
    void Update()
    {

        if (myPlayer.transform.localScale.x > 0)
        {

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //calculates the vector between mouse position and arm position
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //calculate the rotation and convert it to degrees
            if (rotationZ >= -90 && rotationZ <= 90) transform.rotation = Quaternion.Euler(0f, 0f, rotationZ); //actually rotate the arm
        }

        else if (myPlayer.transform.localScale.x < 0)
        {

            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //calculates the vector between mouse position and arm position
            float rotationZ = Mathf.Atan2(-difference.y, -difference.x) * Mathf.Rad2Deg; //calculate the rotation and convert it to degrees
            if (rotationZ >= -90 && rotationZ <= 90) transform.rotation = Quaternion.Euler(0f, 0f, rotationZ); //actually rotate the arm
        }
    }
}
