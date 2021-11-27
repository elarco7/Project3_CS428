using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SurvivorZombie : MonoBehaviour
{
    // Transform properties 
    private Transform target;
    // current survivorZombie as agent
    NavMeshAgent survivorZombie;
    public GameObject parent;
    public GameObject interactableMario;
    private GameObject marioPlayer;


    private void Awake()
    {
        marioPlayer = getMarioChild();
    }

    // Start is called before the first frame update
    void Start()
    {
        // get Target
        target = marioPlayer.transform;
        // get agent properties
        survivorZombie = this.GetComponent<NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (survivorZombie.enabled)
        {
            // destination for survivorZombie
            survivorZombie.destination = target.position;
            // handle animations based on proximity
            if (CheckProximity())
            {
                survivorZombie.GetComponent<Animator>().Play("Z_Attack");

            }
            else
            {
                survivorZombie.GetComponent<Animator>().Play("Z_Run");
            }
        }
        

    }

    // check proximity between survivorZombie and camera
    private bool CheckProximity()
    {
        if ((marioPlayer.transform.position - this.transform.position).sqrMagnitude <= 3 * 3)
        {
            // the player is within a radius of 3 units to this game object
            print("CLOSE TO ATTACK");
            return true;
        }

        return false;
    }

    public void releaseZombie()
    {
        parent.GetComponent<Rigidbody>().isKinematic = false;
    }

    private GameObject getMarioChild()
    {
        var firstChild = interactableMario.transform.GetChild(0);
        var marioChild = firstChild.transform.GetChild(3);
        return marioChild.gameObject;
    }


}
