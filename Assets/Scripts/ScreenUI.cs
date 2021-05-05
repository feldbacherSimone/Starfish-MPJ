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
        destuctionPercent = GameProgress.instance.progressPercent;
        repairPercentTEXT.text = destuctionPercent.ToString() + "%";
    }
}
