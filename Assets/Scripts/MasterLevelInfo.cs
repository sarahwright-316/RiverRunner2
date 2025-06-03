using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterInfo : MonoBehaviour
{
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;
    public static int DistanceCount = 0;
    [SerializeField] GameObject DistanceDisplay;

    void Start(){
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
        DistanceDisplay.GetComponent<TMPro.TMP_Text>().text = "DISTANCE: " + DistanceCount;


    }
}