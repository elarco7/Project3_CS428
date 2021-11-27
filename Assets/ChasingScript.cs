using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingScript : MonoBehaviour
{
    // Tracks target transform values
    private Transform targetCam;
    // Current crawler
    public GameObject crawler;
    // Type stores mp3 assigned to variables
    public AudioSource attackAudio;
    public AudioSource walkAudio;
    public AudioSource walkFastAudio;
    public GameObject parent;
    public GameObject interactableMario;
    private GameObject marioPlayer;


    private void Awake()
    {
       // marioPlayer = getMarioChild();
    }

    // Start is called before the first frame update
    void Start()
    {
        marioPlayer = getMarioChild();
        // Get Camera to be the target
        targetCam = marioPlayer.transform;       
    }

    // Update is called once per frame
    void Update()
    {
        // Crawler will now go to this position
        crawler.GetComponent<NavMeshAgent>().SetDestination(targetCam.position);
        // Handle animations
        handleTarget();
        
    }

    // Check distance between crawler and Camera
    private bool CheckProximity(int distance)
    {
        if ((marioPlayer.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            // the player is within a radius of 3 units to this game object

            print("Testing new target distance");
            return true;
        }

        return false;
    }

    // Check proximity and plays animation accordingly
    private void handleTarget()
    {

        if (CheckProximity(2) || CheckProximity(3))
        {
            crawler.GetComponent<Animator>().Play("attack");
            //walkFastAudio.Play();
            
        }
        else if (CheckProximity(1))
        {
            crawler.GetComponent<Animator>().Play("crawl");
        }
        else
        {
            crawler.GetComponent<Animator>().Play("crawl_fast");
            //attackAudio.Play();
        }
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
