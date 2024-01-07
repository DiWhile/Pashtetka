using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfActivities : MonoBehaviour
{
    public string activitiesName;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Worker")
        {
            isDone();
        }
    }


    public void isDone()
    {
        print("this shit is done");
    }

}
