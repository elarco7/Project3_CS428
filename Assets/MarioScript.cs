using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MarioScript : MonoBehaviour
{
    NavMeshAgent marioAgent;
    public GameObject rightController;
    private bool isAgent;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        marioAgent = this.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if (marioAgent.enabled)
        {
            marioAgent.destination = rightController.transform.position;
            handleAnimations();
            
        }
       
    }


    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 2))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    private bool CheckProximity(int distance)
    {
        if ((rightController.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            //isClostToTarget = true;
            return true;
        }
        return false;
    }

    private void handleAnimations()
    {
        if (marioAgent.enabled)
        {           

            // Handle animations based on proximity
            if (CheckProximity(2) || CheckProximity(3) || CheckProximity(1))
            {
                print("Im close to camera");
                marioAgent.GetComponent<Animator>().Play("Walk");
            }
            else
            {
                marioAgent.GetComponent<Animator>().Play("Running2");
            }
        }
    }

    public void releaseZombie()
    {
        parent.GetComponent<Rigidbody>().isKinematic = false;
    }
}
