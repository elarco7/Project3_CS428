using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFlashLight : MonoBehaviour
{
   

    private void Update()
    {
        if (TouchButton.isPressed)
        {
            getFlashLight();
        }
    }

    private void getFlashLight()
    {
        print("Inside FlashLight script");
        
        print("After Instantiating");
    }
}
