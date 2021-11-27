using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingCrawler2 : MonoBehaviour
{
    private Transform target;
    NavMeshAgent crawler;
    private Animator animator;
 

    // Start is called before the first frame update
    void Start()
    {

        target = Camera.main.transform;
        crawler = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(target);

       
        crawler.destination = Camera.main.transform.position;
        animator.SetBool("crawl", true);
        animator.SetBool("crawl_fast", true);
        


        if (CheckProximity(1))
        {

            print("ATTACK");
        }
        /*
        else if (CheckProximity(3))
        {
            animator.SetBool("attack", false);
            animator.SetBool("crawl", true);
            animator.SetBool("crawl_fast", true);
            animator.SetBool("pounce", true);

            print("RUN AND POUNCE");

        }
        else if (CheckProximity(4))
        {
            animator.SetBool("attack", false);
            animator.SetBool("crawl", false);
            animator.SetBool("crawl_fast", true);
            animator.SetBool("pounce", true);
            print("RUN");
        }
        */



    }

    private bool CheckProximity(int distance)
    {
        if ((Camera.main.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            // the player is within a radius of 3 units to this game object

            print("ATTACK");
            return true;
        }


        return false;
    }
}
