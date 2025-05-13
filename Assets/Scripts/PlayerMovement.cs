using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 7f;
    private float horizontalSpeed = 5f;
    private float rightLimit = 7.8f;
    private float leftLimit = -7.8f;
    private float accelerationRate = 0.07f;    // Units per second added to playerSpeed

    void Update()
    {
        // Gradually increase forward speed
        playerSpeed += accelerationRate * Time.deltaTime;

        //deltaTime: realtive to game speed
        //Space.World: relative to game world
        transform.Translate(Vector3.forward * Time.deltaTime *playerSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {

            if(this.gameObject.transform.position.x > leftLimit){

                transform.Translate(Vector3.left * Time.deltaTime *horizontalSpeed);

            }

        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){

            if(this.gameObject.transform.position.x < rightLimit){

                transform.Translate(Vector3.left * Time.deltaTime *horizontalSpeed * -1);

            }

        }

    }
}
