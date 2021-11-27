using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{

    public GameObject room;
    public GameObject player;
  
    private static float currentXRotation;
    private static float initialYvalue;
    private static float currentYValue;
    static Quaternion rot;
    private Transform roomObj;
    private Vector3 roomPos;
    private static int count = 90;
    private static bool isActive = true;
    [SerializeField] TextMeshPro watchValue;
    [SerializeField] TextMeshPro watchAngle;
    public GameObject leftMark;
    public GameObject rightMark;
    public GameObject leftMark2;
    public GameObject rightMark2;
    public static bool isChangeL2 = false;
    public static bool isChangeR2 = false;
    Transform one;
    Transform two;
    Transform playerPos;
    

    private void Awake()
    {
        initialYvalue = room.GetComponent<Transform>().position.y;
        roomObj = room.GetComponent<Transform>();
        //initialRoomPos = room.GetComponent<Transform>().position;


    }

 
    // Update is called once per frame
    void Update()
    {
        
        currentXRotation = room.GetComponent<Transform>().localRotation.x;
      
        roomPos = room.GetComponent<Transform>().localPosition;
        currentYValue = room.GetComponent<Transform>().localPosition.y;
        //one = rightMark.transform;
        //two = leftMark.transform;
        //playerPos = player.transform;
        //rot = room.GetComponent<Transform>().rotation;
        print("ANGLES: " + room.GetComponent<Transform>().localRotation.eulerAngles);
        print("ANGLE_X: " + room.GetComponent<Transform>().localRotation.eulerAngles.x);
        print("POSITIONS: " +roomPos);
        print("POSITION_Y: " +currentYValue);

        /*
        if (CheckProximity(leftMark2))
            watchAngle.text = "R2.True";
        else
            watchAngle.text = "R2.False";
        /*
        if (currentXRotation == 180)
        {
            print("ANGLEXXXXXXXX: " + currentXRotation);
            room.GetComponent<Transform>().position.Set(0, initialYvalue + 5.45f, 0);
            print("PositionXXXXx: " + room.GetComponent<Transform>().position.x + " " + room.GetComponent<Transform>().position.y + " " + room.GetComponent<Transform>().position.z);
        }
        if (currentXRotation == 360 || currentXRotation == 0)
        {
            print("??????");
            room.GetComponent<Transform>().position.Set(0, initialYvalue, 0);
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LeftHand"))
        {
            if (isActive)
            {
                isActive = false;

                switch (count)
                {
                    case 90:
                        watchValue.text = "90";
                        currentXRotation += 90f;
                        var y = 270f;
                        
                        room.GetComponent<Transform>().Rotate((currentXRotation), 0, 0);
                        room.GetComponent<Transform>().position = new Vector3(0, 5.57f, 0);
                        //if (CheckProximity(rightMark))
                        //player.GetComponent<Transform>().position = player.transform.position + leftMark.transform.position;
                        // if (CheckProximity(rightMark2))
                        // player.GetComponent<Transform>().position = player.transform.position + leftMark2.transform.position;
                        isChangeR2 = true;
                        watchAngle.text = "SET90?";
                        count += 90;
                        
                        break;
                    case 180:
                        watchValue.text = "180";
                        currentXRotation += 90f;
                        var x = 180f;
                        room.GetComponent<Transform>().Rotate((currentXRotation), 0, 0);
                        room.GetComponent<Transform>().position = new Vector3(0, 5.52f, 0);
                       // player.GetComponent<Transform>().Rotate(x, 0, 0);
                        count += 90;
                        
                        break;
                    case 270:
                        watchValue.text = "270";
                        currentXRotation += 90f;
                        var z = 90f;
                        /*
                         * if (CheckProximity(leftMark))
                            player.GetComponent<Transform>().position = player.transform.position + rightMark.transform.position;
                        if (CheckProximity(leftMark2))*/
                              // l2 al l1
                        room.GetComponent<Transform>().Rotate((currentXRotation), 0, 0);                        
                        room.GetComponent<Transform>().position = new Vector3(0, 5.97f, 0);
                        isChangeL2 = true;
                        watchAngle.text = "SET270?";
                        //player.GetComponent<Transform>().position = player.transform.position + new Vector3(two.position.x, two.position.y, two.position.z);
                        // player.GetComponent<Transform>().Rotate(z,0,0);

                        count += 90;
                        break;
                    case 0:
                        watchValue.text = "0";
                        currentXRotation += 90f;
                        room.GetComponent<Transform>().Rotate((currentXRotation), 0, 0);
                        room.GetComponent<Transform>().position = new Vector3(0, 0, 0);
                       // player.GetComponent<Transform>().Rotate(0, 0, 0);
                        count += 90;
                        
                        break;
                    case 360:
                        watchValue.text = "360";
                        currentXRotation += 90f;
                        room.GetComponent<Transform>().Rotate((currentXRotation), 0, 0);
                        room.GetComponent<Transform>().position = new Vector3(0, 0.05f, 0);
                        //player.GetComponent<Transform>().Rotate(0, 0, 0);
                        
                        count += 90;
                        if (count > 360)
                            count = 90;
                        break;
                }
            }
           
                

            print("ANGLE BEFORE: " + room.GetComponent<Transform>().localRotation.x);
           
            //room.GetComponent<Transform>().localRotation =  Quaternion.Euler(180f, 0, 0);
            print("ANGLE AFTER: " + room.GetComponent<Transform>().localRotation.x);
     
            //if (room.GetComponent<Transform>().localRotation.eulerAngles.x > 0  && room.GetComponent<Transform>().localRotation.eulerAngles.x < 357)
             //   room.GetComponent<Transform>().position = new Vector3(0, 5.45f,0);
           // else
              //  room.GetComponent<Transform>().position = new Vector3(0, 0, 0);

            var pos = room.GetComponent<Transform>().position.y;

            print("POS: " + pos);

            print("Position: " + room.GetComponent<Transform>().position.x + " " + room.GetComponent<Transform>().localPosition.y + " " + room.GetComponent<Transform>().position.z);
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        isActive = true;
    }

    private bool CheckProximity(GameObject obj)
    {
        if ((obj.transform.position - player.transform.position).sqrMagnitude <= 7 * 7)
        {
            // the player is within a radius of 3 units to this game object
            print("CLOSE TO ATTACK");
            return true;
        }

        return false;
    }
}
