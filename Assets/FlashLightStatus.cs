using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightStatus : MonoBehaviour
{
    public static bool isActive;

    public void setLightOnStatus()
    {
        isActive = true;
    }
    public void setLightOffStatus()
    {
        isActive = false;
    }
}
