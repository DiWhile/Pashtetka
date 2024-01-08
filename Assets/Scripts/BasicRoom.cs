using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRoom : MonoBehaviour
{
    public string roomName;
    public bool roomIsActive = false;

    public List<PointOfActivities> pointsOfActivities = new List<PointOfActivities>();
 

    private void FixedUpdate()
    {
        foreach (var point in pointsOfActivities)
        {
            if (point.workIsDone == true)
            {
                point.gameObject.SetActive(false);
            }
        }
    }


   


}
