using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    public Transform player;
    private float nextTriggerPos = -26f; //player starts at -21
    void Update()
    {
        while (player.position.z >= nextTriggerPos)
        {
            MasterInfo.DistanceCount += 1;
                nextTriggerPos += 5.0f;
        }
   
    }
}
