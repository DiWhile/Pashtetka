using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOfActivities : MonoBehaviour
{
    public string activitiesName;
    public bool workIsDone = false;

    [Header("Время на задачу")]

    [SerializeField] private float timeToMakeJob = 5;
    [SerializeField] private Image timerImage;

    private float _timeLeft = 0f;
    private bool timerRunning = false;

    private IEnumerator StartTimer()
    {
        print("Старт корутины");
        timerRunning = true;

        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            var normalizedValue = Mathf.Clamp01(_timeLeft / timeToMakeJob);
            timerImage.fillAmount = normalizedValue;
            yield return null;
        }

        IsDone();
        timerRunning = false;
    }

    private void Start()
    {
        _timeLeft = timeToMakeJob;
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Worker" && !timerRunning)
        {
            print("Вошёл в зону деятельности");
            StartCoroutine(StartTimer());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Worker" && timerRunning)
        {
            print("Покинул зону деятельности");
            StopAllCoroutines();
            timerRunning = false;

            _timeLeft = timeToMakeJob;
            var normalizedValue = Mathf.Clamp01(_timeLeft / timeToMakeJob);
            timerImage.fillAmount = normalizedValue;


        }
    }


    public void IsDone()
    {
        print($"{activitiesName} isDone");
        workIsDone = true;
    }






}
