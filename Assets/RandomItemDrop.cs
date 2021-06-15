using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemDrop : Collectable
{
    public float minTime = 10;
    public float maxTime = 100;
    public int dropAmmount = 3; 

    public override void destroy(bool destroyItem) //I just learned what overrides are -_- why do I have to keep finding this stuff through dodgy reddit threads 
        //on another note my lung kinda hurts when I breath 
        //is that normal
        //it better be 
        //I dont wanna die with this being the last thing I'm doing ;-; 

    {      
        base.destroy(false);
    }

    IEnumerator DropItems()
    {
        while (dropAmmount != 0)
        {
           
            destroy(false);
            dropAmmount--;
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
    private void Start()
    {
        StartCoroutine(DropItems());
    }



}
