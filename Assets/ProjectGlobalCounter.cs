using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectGlobalCounter : MonoBehaviour
{
    static DateTime timeStarted;
    static TimeSpan timeSpan;

    public static void StartCountDown(TimeSpan totalTime)
    {
        timeStarted = DateTime.UtcNow;
        timeSpan = totalTime;
    }

    public static TimeSpan timeLeft()
    {

        var result = timeSpan - (DateTime.UtcNow - timeStarted);
        if (result.TotalSeconds <= 0)
            return TimeSpan.Zero;
        return result;
    }
}
