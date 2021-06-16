using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public  List<Task> tasks = new List<Task>();
    public static GameProgress instance;
    public int progressPercent = 0;
    public TaskDisplay taskDisplay;


    private void Awake()
    {
        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
        BuildTaskList();
    }

    void BuildTaskList()
    {
       

        tasks = new List<Task>()
        {
            new Task("Light", 0, "Find Find Recourcess to craft a light", false),
            new Task("Patch Holes", 1, "Patch holes on outside of ship with a glue", false),
            new Task("Battery", 2, "Find a way to repair the ship's energy supply", false),
            new Task("Fuel", 3, "Craft fuel for the ship's engine", false)

        };
    }

   public  void UpdateTaskDisplay()
    {
        progressPercent = 0;
        taskDisplay = GameObject.FindGameObjectWithTag("Screen").GetComponent<TaskDisplay>();
        taskDisplay.Clear();
        taskDisplay.DisplayTasks();
        foreach (Task task in tasks)
        {
                if (task.status == true)
            {
                progressPercent += 25;
            }
        }
    }
   
}
