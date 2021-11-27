using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleLight : MonoBehaviour
{
    private GameObject light1;
    private GameObject light2;

    private void Start()
    {
        light1 = GameObject.FindWithTag("PoleLight");
        light2 = GameObject.FindWithTag("PoleLight2");
    }

    public void turnOnPoleLight()
    {
       
        light1.GetComponent<Light>().enabled = true;
        light2.GetComponent<Light>().enabled = true;
    }

    public void turnOffPoleLight()
    {
        light1.GetComponent<Light>().enabled = false;
        light2.GetComponent<Light>().enabled = false;
    }
}
