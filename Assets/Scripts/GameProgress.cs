﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public static GameProgress instance;
    public int progressPercent; 


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
            new Task("Batterie", 0, "Find Energysource to recharge batterie"),
            new Task("Patch Holes", 1, "Patch holes on outside of ship with a glue", true)

        };
    }
}