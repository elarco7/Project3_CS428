using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProjectTimer : MonoBehaviour
{
    [SerializeField] TextMeshPro watchAngle;
    public static bool isActive = false;
    private static bool isTimeStarted = false;
    private static float currentTime = 5 * 60;
    private static TimeSpan theTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        theTime = ProjectGlobalCounter.timeLeft();
        watchAngle.text = theTime.Minutes.ToString() + ":" + theTime.Seconds.ToString();
        if (theTime <= TimeSpan.Zero)
        {
            isActive = false;
            watchAngle.text = "Timer";
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            if (!isActive)
            {
                ProjectGlobalCounter.StartCountDown(TimeSpan.FromSeconds(300));
                isActive = true;
            }
        }
    }


}
