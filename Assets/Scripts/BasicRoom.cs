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
        List<PointOfActivities> pointsToRemove = new List<PointOfActivities>();

        foreach (var point in pointsOfActivities)
        {
            if (point.workIsDone)
            {
                pointsToRemove.Add(point);
            }
        }

        foreach (var point in pointsToRemove)
        {
            point.OnDestroy();
            pointsOfActivities.Remove(point);
        }
    }
}
