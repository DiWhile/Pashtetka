using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOfActivities : MonoBehaviour
{
    public string activitiesName;
    public bool workIsDone = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Worker")
        {
            workIsDone = true;
            IsDone();
        }
    }

    public void IsDone()
    {
        print($"{activitiesName} isDone");
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }
}
