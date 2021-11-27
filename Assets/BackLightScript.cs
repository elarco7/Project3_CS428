using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BackLightScript : MonoBehaviour
{
    public GameObject lightObj;
    private static int count = 0;
    [SerializeField] TextMeshPro onOFF;
    private bool isActive;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        onOFF.text = "HELLO";
        if (other.CompareTag("LeftHand"))
        {
            if (count % 2 == 0)
            {
                lightObj.GetComponent<Light>().enabled = true;
                isActive = true;
                onOFF.text = "ON";
            }
            else
            {
                lightObj.GetComponent<Light>().enabled = false;
                isActive = false;
                onOFF.text = "OFF";
            }

        }
            
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            if(isActive)
                onOFF.text = "ON";
            else
                onOFF.text = "OFF";

            count++;
        }
            
    }
}
