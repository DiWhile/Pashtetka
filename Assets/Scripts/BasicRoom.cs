using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRoom : MonoBehaviour
{
    public string roomName;
    public bool roomIsActive = false;

    public List<PointOfActivities> pointsOfActivities = new List<PointOfActivities>();

    public List<PointOfActivities> reservPointsOfActivities = new List<PointOfActivities>();


    
    private void FixedUpdate()
    {
        if (pointsOfActivities.Count != 0)
        {

            for (int i = pointsOfActivities.Count - 1; i >= 0; i--)
            {
                var point = pointsOfActivities[i];

                if (point.workIsDone)
                {
                    if (point.gameObject.tag == "Money")
                    {
                        GameObject.Find("MoneyCounter").GetComponent<MoneyCounter>().receivedMoney = point.money;
                    }
                    point.gameObject.SetActive(false);
                    reservPointsOfActivities.Add(point);
                    pointsOfActivities.RemoveAt(i);
                }
            }
        }
    
            // тут выполнить условие можно и вернуть все обьекты с резерва
        
    }





}
