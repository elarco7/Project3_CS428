using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public GameObject elevator;
    private static bool isGround = true;
    private Vector3 originalPosition;
    private bool test;
    // Start is called before the first frame update

    private void Awake()
    {
        originalPosition = elevator.transform.position;
        //StartCoroutine(ActivateElevator());
    }
    private void OnTriggerStay()
    {
        

        if (isGround )
        {
            elevator.transform.position += elevator.transform.up * Time.deltaTime;
            isGround = false;
            print("Elevator is on second floor");
        }
        else
        {
            elevator.transform.position -= originalPosition * Time.deltaTime;
            isGround = true;
            test = false;
            print("Elevator is on first floor");

        }
    }

    IEnumerator ActivateElevator()
    {

        yield return new WaitForSeconds(20);
        test = true;

    }

}
