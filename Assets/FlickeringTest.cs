using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringTest : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isFlickering = false;
    private float timeDelay;
    // Update is called once per frame
    void Update()
    {
        

       if (FlashLightStatus.isActive)
        {
            this.gameObject.GetComponent<Light>().enabled = false;
        }
        else
        {
            this.gameObject.GetComponent<Light>().enabled = true;
            /*
            if (!isFlickering)
            {
                StartCoroutine(EnableFlickering());
            }
            */
        }
       

        /*
        if (!isFlickering)
        {
            StartCoroutine(EnableFlickering());
        }
        */
    }

    IEnumerator EnableFlickering()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;

    }
}
