using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEnabler : MonoBehaviour
{
    public GameObject flashLight;

    public void turnONLight()
    {
        flashLight.GetComponent<Light>().enabled = true;
    }

    public void turnOFFLight()
    {
        flashLight.GetComponent<Light>().enabled = false;
    }
}
