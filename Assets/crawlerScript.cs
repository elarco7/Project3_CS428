using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crawlerScript : MonoBehaviour
{
    // Get Transform values of target
    private Transform target;
    // current zombie agent
    NavMeshAgent zombie;
    // Get transform values of survivor
    public Transform survivor;
    // Type will store mp3 in these variables
    public AudioSource attackAudio;
    public AudioSource walkAudio;
    public AudioSource walkFastAudio;
    public GameObject parent;


    // Start is called before the first frame update
    void Start()
    {
        // Get Camera properties
        target = Camera.main.transform;
        // Get zombie as Nav agent properties
        zombie = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Condition check bool value from Survivor Script
        if (SurvivorScript.survivorChased)
        {
            // update destination for zombie
            zombie.destination = survivor.position;
            // handle animations
            handleTarget();
        }
        /*
        else
        {
            // zombie keeps current destination
            zombie.destination = target.position;
            // handle animations
            handleTarget();
        }
        */
    }

    // Checks if survivor is close to crawler
    private bool CheckProximityToSurvivor(int distance)
    {
        if ((survivor.position - this.transform.position).sqrMagnitude <= distance * distance)
        {

            print("ATTACK");
            return true;
        }
        return false;
    }

    // Handles animations based on proximity
    private void handleTarget()
    {               

        if (CheckProximityToSurvivor(2) || CheckProximityToSurvivor(3))
        {
            zombie.GetComponent<Animator>().Play("attack");
            walkFastAudio.Play();
        }
       
        else if (CheckProximityToSurvivor(1))
        {
            zombie.GetComponent<Animator>().Play("crawl");
            walkAudio.Play();
        }
        else
        {
            zombie.GetComponent<Animator>().Play("crawl_fast");
            //attackAudio.Play();
        }        
    }

    public void releaseZombie()
    {
        parent.GetComponent<Rigidbody>().isKinematic = false;
    }
}
