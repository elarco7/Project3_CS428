using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombieScript : MonoBehaviour
{
    private Transform target;
    NavMeshAgent zombie;
    public GameObject parent;
    private GameObject marioPlayer;
    public GameObject interactableMario;

    private void Awake()
    {
        marioPlayer = getMarioChild();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Target will be the current Camera 
        target = marioPlayer.transform;
        // Get NaveMeshAgent component
        zombie = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       
        // Zombie will always target this position
        zombie.destination = target.position;
        // Check proximit and play animation accordingly
        if (CheckProximity()){
            zombie.GetComponent<Animator>().Play("Z_Attack");
        }
        else
        {
            zombie.GetComponent<Animator>().Play("Z_Walk");
        }       

    }

    // Check distance between zombie and Camera
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
