using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenUI : MonoBehaviour
{
    [SerializeField]
    TextMeshPro repairPercentTEXT;
    [SerializeField]
    int destuctionPercent;
    

    private void Update()
    {
        repairPercentTEXT.text = destuctionPercent.ToString() + "%";
    }
}
