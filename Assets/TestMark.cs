using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMark : MonoBehaviour
{
    public GameObject player;
    //public GameObject rightMark;
    private Transform obj;
    private Vector3 objV;
    private bool isTouched = true;
    private float speed = 5f;
    public static bool test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //obj = rightMark.transform;
       // objV = obj.localPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("LeftHand"))
        {
           
                //float step = speed * Time.deltaTime;
                //Vector3 directionToMove = obj.position - player.GetComponent<Transform>().position;
                //directionToMove = directionToMove.normalized * Time.deltaTime * speed;
                ////float maxDistance = Vector3.Distance(player.GetComponent<Transform>().position, obj.position);
                //player.GetComponent<Transform>().position = player.GetComponent<Transform>().position + Vector3.ClampMagnitude(directionToMove, maxDistance);

                print("HEY");
            // transform.position = new Vector3(objV.x + 1, objV.y + 1, objV.z + 1);
            test = true;
            //player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(objV.x + 1, objV.y + 1, objV.z + 1), step);
            //isTouched = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("EXIT");
        isTouched = true;
    }
}
