using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    public static Transform playerPos;
    [SerializeField] GameObject DistanceDisplay;

    void Start(){
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + 0;
    }
    void Update()
    {
        if (coinCount < 1000)
        {
            coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: " + coinCount;
        }
        else
        {
            coinDisplay.GetComponent<TMPro.TMP_Text>().text = "COINS: 999+";
        }
        
        if (playerPos != null && DistanceDisplay != null)
        {
            int distance = Mathf.FloorToInt(playerPos.position.z) + 21;
            if (distance < 10000)
            {
                DistanceDisplay.GetComponent<TMPro.TMP_Text>().text = "DISTANCE: " + distance + " m";
            }
            else
            {
                DistanceDisplay.GetComponent<TMPro.TMP_Text>().text = "DISTANCE: 9999+ m";
            }
        }
    }
}