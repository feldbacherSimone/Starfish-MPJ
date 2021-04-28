using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public string name;
    public int id;
    public string description;

    public bool status = false; 

    public Task(string name, int id, string description)
    {
        this.name = name;
        this.id = id;
        this.description = description;
    }
    public Task(string name, int id, string description, bool status)
    {
        this.name = name;
        this.id = id;
        this.description = description;
        this.status = status; 
    }
}
