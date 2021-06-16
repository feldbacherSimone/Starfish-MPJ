using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class TaskDisplay : MonoBehaviour
{
    public GameObject refernce;
    public Transform positoning; 
    public Color colorMissing;
    public Color colorDone;
    public float offsetAmount;

    private void Start()
    {
        DisplayTasks();
    }

    public void DisplayTasks()
    {
        GameProgress.instance.progressPercent = 0;

        float offset = 0;
        foreach (Task task in GameProgress.instance.tasks)
        {
            
            GameObject layout = Instantiate(refernce, gameObject.transform);
            layout.transform.position += new Vector3(0, offset, 0);
            offset += offsetAmount;

            TextMeshPro name = layout.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
            TextMeshPro description = layout.transform.GetChild(1).gameObject.GetComponent<TextMeshPro>();
            TextMeshPro status = layout.transform.GetChild(2).gameObject.GetComponent<TextMeshPro>();

            name.text = task.name;
            description.text = task.description;

            if (task.status == true) {
                status.text = "O";
                status.color = colorDone;
                GameProgress.instance.progressPercent += 30;
            }
            else
            {
                status.text = "X";
                status.color = colorMissing; 
            }

        }
    }
    public void Clear()
    {
        foreach (Transform child in transform)
        {
            if (child.GetSiblingIndex() > 0)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
