using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dualModeZombie : MonoBehaviour
{
    // First zombie
    public GameObject zombieEating;
    // Second zombie
    public GameObject zombieEating2;
    // First zombie as agent
    public GameObject agentZombie2;
    // Second zombie as agent
   
    public GameObject interactableAgentZombie;
    public GameObject interactableMario;
    private GameObject marioPlayer;
    // Condition will change when zombie changes to agent
    bool isActive = true;
    // Check when zombie is not laying on the floor
    public static bool isUp = false;
    private bool wasReset;

    private void Awake()
    {
        marioPlayer = getMarioChild();
    }


    // Start is called before the first frame update
    void Start()
    {
        // Just set their conditions as obstacles to true
        //zombieEating.GetComponent<NavMeshObstacle>().enabled = true;
        //zombieEating2.GetComponent<NavMeshObstacle>().enabled = true;
        // Coroutine will start once condition is met
        StartCoroutine(ChangeZombieMode());
    }

    // Update is called once per frame
    void Update()
    {
        
        
        // Zombies are still obstacles
        if (isActive)
        {
            zombieEating.GetComponent<NavMeshObstacle>().enabled = true;
            //zombieEating2.GetComponent<NavMeshObstacle>().enabled = true;
            isUp = false;
        }

        // Zombies are not obstacles anymore
        else
        {
            if (!wasReset)
            {
                zombieEating.GetComponent<NavMeshObstacle>().enabled = false;
                //zombieEating2.GetComponent<NavMeshObstacle>().enabled = false;
                // Disable zombies
                zombieEating.SetActive(false);
                //zombieEating2.SetActive(false);
                // Enables agent zombies
                if (interactableAgentZombie.active == false)
                {
                    interactableAgentZombie.SetActive(true);
                    //agentZombie2.SetActive(true);
                    isUp = true;
                }
                wasReset = true;
            }
           
        }  
        
    }

    // Coroutine will wait until user gets near eating zombies
    IEnumerator ChangeZombieMode()
    {
        isActive = true;
        yield return new WaitUntil(CheckProximity);
        
        /*
        zombieEating.GetComponent<NavMeshObstacle>().enabled = false;
        zombieEating.SetActive(false);
        if (interactableAgentZombie.active == false)
        {
            interactableAgentZombie.SetActive(true);
            //agentZombie2.SetActive(true);
            isUp = true;
        }
        */
        
        // Condition met, change status for isActive
        isActive = false;
        
    }

    // Check proximity between Camera and zombies
    private bool CheckProximity()
    {
        if ((marioPlayer.transform.position - this.transform.position).sqrMagnitude <= 3 * 3)
        {
            // the player is within a radius of 3 units to this game object
            print("CLOSE TO ZOMBIE");
            return true;
        }

        return false;
    }

    private GameObject getMarioChild()
    {
        var firstChild = interactableMario.transform.GetChild(0);
        var marioChild = firstChild.transform.GetChild(3);
        return marioChild.gameObject;
    }
}
