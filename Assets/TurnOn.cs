using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flashLight;

    void turnONLight()
    {
        flashLight.GetComponent<Light>().enabled = true;
    }

    void turnOFFLight()
    {
        flashLight.GetComponent<Light>().enabled = false;
    }
}
