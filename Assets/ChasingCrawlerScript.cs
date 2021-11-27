using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingCrawlerScript : MonoBehaviour
{
    // Transform properties for target
    private Transform target;
    // current crawler
    public GameObject chasingCrawler;
    // Transform properties of survivor    
    public GameObject interactableSurvivor;
    private GameObject survivorChild;
    // Objects that will trigger crawler
    private GameObject triggerToSurvivor;
    private GameObject triggerToCamera;
    // keep status of targets
    private static bool isCameraTarget;
    private static bool isInitTarget = true;    
    private bool wasReset;
    // crawler that will replace chasing crawler
    public GameObject interactableCrawlerX;
    private GameObject crawlerXChild;
    // will keep location of chasing crawler
    Vector3 location;
    public GameObject parent;
    public GameObject interactableMario;
    private GameObject marioPlayer;


    private void Awake()
    {
        marioPlayer = getMarioChild();
        /*
        wasReset = false;
        isCameraTarget = false;
        isInitTarget = true;
        */
        //chasingCrawler.SetActive(true);
        //interactableCrawlerX.SetActive(false);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // get Camera as target
        target = marioPlayer.transform;
        // get objects that will trigger actions
        triggerToSurvivor = GameObject.FindWithTag("TargetCube");
        triggerToCamera = GameObject.FindWithTag("TargetCamera");
        survivorChild = getSurvivorChild();
        crawlerXChild = getCrawlerXChild();
        interactableCrawlerX.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // validate condition to change target
        if (isCameraTarget)
        {          
            
            if (!wasReset)
            {
                // condition won't be triggered again
                wasReset = true;
                // get current location of chasingcrawler
                location = chasingCrawler.transform.position;
                // disable chasingcrawler
                chasingCrawler.SetActive(false);
                // update location for new crawler
                interactableCrawlerX.transform.position = location;
                // enable crawler
                interactableCrawlerX.SetActive(true);
                
            }
            // Handle animations based on proximity    
            handleTarget();
        }
        else
        {
            // target still the same
            if( isInitTarget )
            {    
                // check proximity with trigger obj
                if (CheckProximityToCamera(3, triggerToSurvivor))
                {
                    // check proximity with trigger obj                                     
                    if (CheckProximityToInitialTarget(3, triggerToSurvivor))
                    {
                        // set destination for original chasingcrawler
                        chasingCrawler.GetComponent<NavMeshAgent>().SetDestination(survivorChild.transform.position);
                        // play animation
                        chasingCrawler.GetComponent<Animator>().Play("crawl");
                    }
                    else
                    {
                        // set destination for original chasingcrawler
                        chasingCrawler.GetComponent<NavMeshAgent>().SetDestination(survivorChild.transform.position);
                        // play animation
                        chasingCrawler.GetComponent<Animator>().Play("crawl_fast");
                    }
                                       
                }
                // check proximity
                if (CheckProximityToCamera(3, triggerToCamera))
                {
                    print("NEW destination to be set");
                    isInitTarget = false;
                    isCameraTarget = true;
                }
            }  
        }

    }

    // Check proximity against camera and obj
    private bool CheckProximityToCamera(int distance, GameObject obj)
    {
        if ((marioPlayer.transform.position - obj.transform.position).sqrMagnitude <= distance * distance)
        {
            print("Close to Cubicle");
            return true;
        }

        return false;
    }

    // check proximity against initial target
    private bool CheckProximityToInitialTarget(int distance, GameObject obj)
    {
        if ((obj.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            print("ATTACK");
            return true;
        }

        return false;
    }

    // check proximity
    private bool CheckProximity(int distance)
    {
        if ((marioPlayer.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            print("Testing new target distance");
            return true;
        }

        return false;
    }

    // Coroutine will change target for crawler
    IEnumerator SwitchToFinalTarget()
    {
        
        yield return new WaitForSeconds(2);
        // set new destination
        chasingCrawler.GetComponent<NavMeshAgent>().SetDestination(target.position);
        // handle animations  
        handleTarget();

    }

    // Plays animations based on proximity
    private void handleTarget()
    {
        print("SET NEW POSITION?");
        if (CheckProximity(2) || CheckProximity(3))
        {         
           if(chasingCrawler.active == true)
            {
                chasingCrawler.GetComponent<Animator>().Play("crawl");
            }          
        }
        else if (CheckProximity(1))
        {
            if (chasingCrawler.active == true)
            {
                chasingCrawler.GetComponent<Animator>().Play("attack");
            }
        }
        else
        {
            if (chasingCrawler.active == true)
            {
                chasingCrawler.GetComponent<Animator>().Play("crawl_fast");
            }
        }
    }

    private GameObject getSurvivorChild()
    {
        var firstChild = interactableSurvivor.transform.GetChild(0);
        var survivorChild = firstChild.transform.GetChild(3);
        return survivorChild.gameObject;
    }

    private GameObject getCrawlerXChild()
    {
        var firstChild = interactableCrawlerX.transform.GetChild(0);
        var survivorChild = firstChild.transform.GetChild(3);
        return survivorChild.gameObject;
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
