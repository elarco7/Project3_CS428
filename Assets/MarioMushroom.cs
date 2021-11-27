using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMushroom : MonoBehaviour
{
    //public AudioSource audio;
    public GameObject mario;
    Transform marioPos;
    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       // marioPos = mario.transform;
        //if (CheckProximity(marioPos))
          //  audio.Play();
    }

    private bool CheckProximity(Transform obj)
    {
        if ((this.transform.position - obj.position).sqrMagnitude <= 3 * 3)
        {
            // the player is within a radius of 3 units to this game object

            print("Testing new target distance");
            return true;
        }

        return false;
    }
}
