using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    // status if button is pressed
    public static bool isPressed;
    // item vending machine will have
    public GameObject flashLight;
    // object where item will land on
    public GameObject Target;


    private void OnTriggerEnter(Collider other)
    {
        // validate if button is still pressed
        if (!isPressed)
        {
            // spawn a new flashligt
            Instantiate(flashLight, Target.transform.position, Target.transform.rotation);
            isPressed = true;
            //StartCoroutine(SwitchToFinalTarget());
        }        

        print("Button pressed");
    }

    private void OnTriggerExit(Collider other)
    {
        // button not pressed any more
        isPressed = false;
        print("Button unpressed");
    }



}
