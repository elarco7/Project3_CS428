using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RaySelector : MonoBehaviour
{
    [SerializeField] private string objectTag = "Grabbable";
    [SerializeField] private string survivorTag = "GrabbableSurvivor";
    [SerializeField] private string chasingCrawlerTag = "GrabbableChasingCrawler";
    [SerializeField] private string crawlerXTag = "GrabbableCrawlerX";
    [SerializeField] private string crawlerTag = "GrabbableCrawler";
    [SerializeField] private string crawlerCopyTag = "GrabbableCrawlerCopy";
    [SerializeField] private string survivorZombieTag = "GrabbableSurvivorZombie";
    [SerializeField] private string vendingMachineButtonTag = "vendingMachineButton";
    [SerializeField] private string zombieToEnableTag = "GrabbableZombieToEnable";
    [SerializeField] private string zombieToGetUpTag = "GrabbableZombieToGetUp";
    [SerializeField] private string marioTag = "GrabbableMario";

    public GameObject interactableZombie;
    private GameObject interactableZombieChild;

    public GameObject interactableSurvivor;
    private GameObject interactableSurvivorChild;

    public GameObject interactableChasingCrawler;
    private GameObject interactableChasingCrawlerChild;

    public GameObject interactableCrawlerX;
    private GameObject interactableCrawlerXChild;

    public GameObject interactableCrawler;
    private GameObject interactableCrawlerChild;

    public GameObject interactableCrawlerCopy;
    private GameObject interactableCrawlerCopyChild;

    public GameObject interactableSurvivorZombie;
    private GameObject interactableSurvivorZombieChild;

    public GameObject interactableZombieToEnable;
    private GameObject interactableZombieToEnableChild;

    public GameObject interactableZombieToGetUp;
    private GameObject interactableZombieToGetUpChild;

    public GameObject interactableMario;
    private GameObject interactableMarioChild;

    public GameObject flashLight;
    // object where item will land on
    public GameObject flashLightTarget;

    public GameObject sodaCan;
    // object where item will land on
    public GameObject sodaCanTarget;


    bool isActive = false;
    public static bool isSurvivorActive = true;
    private bool isChasingCrawlerActive = true;
    private bool isCrawlerXActive = true;
    private bool isCrawlerActive = true;
    private bool isCrawlerCopyActive = true;
    private bool isSurvivorZombieActive = true;
    private bool isFlashLightButtonTouched = false;
    private bool isSodaButtonTouched = false;
    private bool isZombieToEnableActive = true;
    private bool isZombieToGetUpActive = true;
    private bool isMarioActive = true;
    private Transform target;
    public LayerMask grabbableMask;
    // Start is called before the first frame update

    private void Awake()
    {
        
        interactableZombieChild = getChildObject();
        interactableSurvivorChild = getSurvivorChild();
        interactableChasingCrawlerChild = getChasingCrawlerChild();
        interactableCrawlerXChild = getCrawlerXChild();
        interactableCrawlerChild = getCrawlerChild();
        interactableCrawlerCopyChild = getCrawlerCopyChild();
        interactableSurvivorZombieChild = getSurvivorZombieChild();
        interactableZombieToEnableChild = getZombieToEnableChild();
        interactableZombieToGetUpChild = getZombieToGetUpChild();
        interactableMarioChild = getMarioChild();
    }



    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 4.0f, Color.red, 0.5f);
        target = Camera.main.transform;

                

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 8.0f, grabbableMask))
        {
            var selection = hit.transform;
            var d = hit.collider.gameObject.name;
            var tagName = selection.tag;
            print("MY name is: " + tagName);
            switch (tagName)
            {
                case "GrabbableSurvivor":
                    if (!isSurvivorActive)
                    {
                        ObjectIsAgent(interactableSurvivorChild, selection);
                        var script = interactableSurvivorChild.GetComponent<SurvivorScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableSurvivorChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableSurvivorChild, selection);
                        var script = interactableSurvivorChild.GetComponent<SurvivorScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableSurvivorChild",false));
                    }
                    print("Hello Survivor");
                    break;

                case "Grabbable":
                    if (!isActive)
                    {
                        ObjectIsAgent(interactableZombieChild, selection);
                        var script = interactableZombieChild.GetComponent<zombieScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableZombieChild, selection);
                        var script = interactableZombieChild.GetComponent<zombieScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieChild", false));
                    }
                    print("Hello Zombie");
                    break;

                case "GrabbableChasingCrawler":
                    if (!isChasingCrawlerActive)
                    {
                        ObjectIsAgent(interactableChasingCrawlerChild, selection);
                        var script = interactableChasingCrawlerChild.GetComponent<ChasingCrawlerScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableChasingCrawlerChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableChasingCrawlerChild, selection);
                        var script = interactableChasingCrawlerChild.GetComponent<ChasingCrawlerScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableChasingCrawlerChild", false));
                    }
                    print("Hello ChasingCrawler");
                    break;

                case "GrabbableCrawlerX":
                    if (!isCrawlerXActive)
                    {
                        ObjectIsAgent(interactableCrawlerXChild, selection);
                        var script = interactableCrawlerXChild.GetComponent<ChasingScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerXChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableCrawlerXChild, selection);
                        var script = interactableCrawlerXChild.GetComponent<ChasingScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerXChild", false));
                    }
                    print("Hello CrawlerX");
                    break;

                case "GrabbableCrawler":
                    if (!isCrawlerActive)
                    {
                        ObjectIsAgent(interactableCrawlerChild, selection);
                        var script = interactableCrawlerChild.GetComponent<crawlerScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableCrawlerChild, selection);
                        var script = interactableCrawlerChild.GetComponent<crawlerScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerChild", false));
                    }
                    print("Hello Crawler");
                    break;

                case "GrabbableCrawlerCopy":
                    if (!isCrawlerCopyActive)
                    {
                        ObjectIsAgent(interactableCrawlerCopyChild, selection);
                        var script = interactableCrawlerCopyChild.GetComponent<ChasingScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerCopyChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableCrawlerCopyChild, selection);
                        var script = interactableCrawlerCopyChild.GetComponent<ChasingScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableCrawlerCopyChild", false));
                    }
                    print("Hello CrawlerCopy");
                    break;

                case "GrabbableSurvivorZombie":
                    if (!isSurvivorZombieActive)
                    {
                        ObjectIsAgent(interactableSurvivorZombieChild, selection);
                        var script = interactableSurvivorZombieChild.GetComponent<SurvivorZombie>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableSurvivorZombieChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableSurvivorZombieChild, selection);
                        var script = interactableSurvivorZombieChild.GetComponent<SurvivorZombie>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableSurvivorZombieChild", false));
                    
                    }
                    print("Hello SurvivorZombie");
                    break;

                case "GrabbableZombieToEnable":
                    if (!isZombieToEnableActive)
                    {
                        ObjectIsAgent(interactableZombieToEnableChild, selection);
                        var script = interactableZombieToEnableChild.GetComponent<zombieScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieToEnableChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableZombieToEnableChild, selection);
                        var script = interactableZombieToEnableChild.GetComponent<zombieScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieToEnableChild", false));

                    }
                    print("Hello ZombieToEnable");
                    break;

                case "GrabbableZombieToGetUp":
                    if (!isZombieToGetUpActive)
                    {
                        ObjectIsAgent(interactableZombieToGetUpChild, selection);
                        var script = interactableZombieToGetUpChild.GetComponent<zombieScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieToGetUpChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableZombieToGetUpChild, selection);
                        var script = interactableZombieToGetUpChild.GetComponent<zombieScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableZombieToGetUpChild", false));

                    }
                    print("Hello ZombieToGetUp");
                    break;

                case "GrabbableMario":
                    if (!isMarioActive)
                    {
                        ObjectIsAgent(interactableMarioChild, selection);
                        var script = interactableMarioChild.GetComponent<MarioScript>();
                        script.enabled = true;
                        StartCoroutine(SwitchToFinalTarget("interactableMarioChild", true));
                    }
                    else
                    {
                        ObjecIsObstacle(interactableMarioChild, selection);
                        var script = interactableMarioChild.GetComponent<MarioScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget("interactableMarioChild", false));

                    }
                    print("Hello Mario");
                    break;

                case "FlashLightVendingMachine":
                    if (!isFlashLightButtonTouched)
                    {                      
                     
                        // spawn a new flashligt
                        Instantiate(flashLight, flashLightTarget.transform.position, flashLightTarget.transform.rotation);
                        isFlashLightButtonTouched = true;
                        StartCoroutine(SwitchToFinalTarget("FlashLightVendingMachine", false));                   

                    }
                   
                    break;

                case "SodaVendingMachine":
                    if (!isSodaButtonTouched)
                    {

                        // spawn a new flashligt
                        Instantiate(sodaCan, sodaCanTarget.transform.position, sodaCanTarget.transform.rotation);
                        isSodaButtonTouched = true;
                        StartCoroutine(SwitchToFinalTarget("SodaVendingMachine", false));

                    }

                    break;


            }

            /*

            if (selection.CompareTag(objectTag))
            {
                

                if (!isActive)
                {
                    Debug.Log("Collider name: " + interactableZombieChild.name);
                  
                    var isAgent = interactableZombieChild.GetComponent<NavMeshAgent>().enabled ? true : false;
                    Debug.Log("isAgent: " + isAgent);
                    interactableZombieChild.GetComponent<NavMeshObstacle>().enabled = false;
                    Vector3 newDestination2 = Camera.main.transform.position;

                    interactableZombieChild.GetComponent<NavMeshAgent>().enabled = true;
                    selection.GetComponent<Rigidbody>().isKinematic = true;
                    //selection.GetComponent<NavMeshAgent>().destination = target.position;


                    var script = interactableZombieChild.GetComponent<zombieScript>();
                    script.enabled = true;
                    StartCoroutine(SwitchToFinalTarget(true));
                   


                }
                else
                {
                    Debug.Log("Collider name2: " + interactableZombieChild.name);
                  
                    var isAgent = interactableZombieChild.GetComponent<NavMeshAgent>().enabled ? true : false;
                    if (isAgent)
                    {
                        Debug.Log("isAgent2: " + isAgent);

                        interactableZombieChild.GetComponent<NavMeshAgent>().isStopped = true;
                        interactableZombieChild.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                        interactableZombieChild.GetComponent<Animator>().Play("Z_Idle");
                        interactableZombieChild.GetComponent<NavMeshAgent>().enabled = false;
                        interactableZombieChild.GetComponent<NavMeshObstacle>().enabled = true;
                        selection.GetComponent<Rigidbody>().isKinematic = false;
                        var script = interactableZombieChild.GetComponent<zombieScript>();
                        script.enabled = false;
                        StartCoroutine(SwitchToFinalTarget(false));
                    }
                   
                }

            }
            */
        }

    }

    IEnumerator SwitchToFinalTarget(string curObject, bool status)
    {

        switch (curObject)
        {
            case "interactableSurvivorChild":
                yield return new WaitForSeconds(3);
                isSurvivorActive = status;
                break;
            case "interactableZombieChild":
                yield return new WaitForSeconds(3);
                isActive = status;
                break;
            case "interactableChasingCrawlerChild":
                yield return new WaitForSeconds(3);
                isChasingCrawlerActive = status;
                break;
            case "interactableCrawlerXChild":
                yield return new WaitForSeconds(3);
                isCrawlerXActive = status;
                break;
            case "interactableCrawlerChild":
                yield return new WaitForSeconds(3);
                isCrawlerActive = status;
                break;
            case "interactableCrawlerCopyChild":
                yield return new WaitForSeconds(3);
                isCrawlerCopyActive = status;
                break;
            case "interactableSurvivorZombieChild":
                yield return new WaitForSeconds(3);
                isSurvivorZombieActive = status;
                break;
            case "FlashLightVendingMachine":
                yield return new WaitForSeconds(3);
                isFlashLightButtonTouched = status;
                break;
            case "SodaVendingMachine":
                yield return new WaitForSeconds(3);
                isSodaButtonTouched = status;
                break;
            case "interactableZombieToEnableChild":
                yield return new WaitForSeconds(3);
                isZombieToEnableActive = status;
                break;
            case "interactableZombieToGetUpChild":
                yield return new WaitForSeconds(3);
                isZombieToGetUpActive = status;
                break;
            case "interactableMarioChild":
                yield return new WaitForSeconds(3);
                isMarioActive = status;
                break;

        }

        
    }

    GameObject getChildObject()
    {
        var firstChild = interactableZombie.transform.GetChild(0);
        var zombieChild = firstChild.transform.GetChild(3);
        return zombieChild.gameObject;
    }

    private GameObject getSurvivorChild()
    {
        var firstChild = interactableSurvivor.transform.GetChild(0);
        var survivorChild = firstChild.transform.GetChild(3);
        return survivorChild.gameObject;
    }

    private GameObject getChasingCrawlerChild()
    {
        var firstChild = interactableChasingCrawler.transform.GetChild(0);
        var chasingCrawlerChild = firstChild.transform.GetChild(3);
        return chasingCrawlerChild.gameObject;
    }

    private GameObject getCrawlerXChild()
    {
        var firstChild = interactableCrawlerX.transform.GetChild(0);
        var crawlerXChild = firstChild.transform.GetChild(3);
        return crawlerXChild.gameObject;
    }

    private GameObject getCrawlerChild()
    {
        var firstChild = interactableCrawler.transform.GetChild(0);
        var crawlerChild = firstChild.transform.GetChild(3);
        return crawlerChild.gameObject;
    }

    private GameObject getCrawlerCopyChild()
    {
        var firstChild = interactableCrawlerCopy.transform.GetChild(0);
        var crawlerCopyChild = firstChild.transform.GetChild(3);
        return crawlerCopyChild.gameObject;
    }

    private GameObject getSurvivorZombieChild()
    {
        var firstChild = interactableSurvivorZombie.transform.GetChild(0);
        var survivorZombieChild = firstChild.transform.GetChild(3);
        return survivorZombieChild.gameObject;
    }

    private GameObject getZombieToEnableChild()
    {
        var firstChild = interactableZombieToEnable.transform.GetChild(0);
        var zombieToEnableChild = firstChild.transform.GetChild(3);
        return zombieToEnableChild.gameObject;
    }

    private GameObject getZombieToGetUpChild()
    {
        var firstChild = interactableZombieToGetUp.transform.GetChild(0);
        var zombieToGetUpChild = firstChild.transform.GetChild(3);
        return zombieToGetUpChild.gameObject;
    }

    private GameObject getMarioChild()
    {
        var firstChild = interactableMario.transform.GetChild(0);
        var marioChild = firstChild.transform.GetChild(3);
        return marioChild.gameObject;
    }

    private void ObjectIsAgent(GameObject curObject, Transform selection)
    {
        Debug.Log("Collider name: " + curObject.name);

        var isAgent = curObject.GetComponent<NavMeshAgent>().enabled ? true : false;
        Debug.Log("isAgent: " + isAgent);
        curObject.GetComponent<NavMeshObstacle>().enabled = false;

        curObject.GetComponent<NavMeshAgent>().enabled = true;
        selection.GetComponent<Rigidbody>().isKinematic = true;      
        
    }

    private void ObjecIsObstacle(GameObject curObject, Transform selection)
    {
        var isAgent = curObject.GetComponent<NavMeshAgent>().enabled ? true : false;
        if (isAgent)
        {
            Debug.Log("isAgent2: " + isAgent);

            curObject.GetComponent<NavMeshAgent>().isStopped = true;
            curObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            if(curObject.CompareTag(objectTag) || curObject.CompareTag(survivorZombieTag) || curObject.CompareTag(survivorTag) ||
                curObject.CompareTag(zombieToEnableTag) || curObject.CompareTag(zombieToGetUpTag))
                curObject.GetComponent<Animator>().Play("Z_Idle");
            if(curObject.CompareTag(marioTag) || curObject.CompareTag(chasingCrawlerTag) || curObject.CompareTag(crawlerTag) ||
                curObject.CompareTag(crawlerXTag) || curObject.CompareTag(crawlerCopyTag))
                curObject.GetComponent<Animator>().Play("Idle");
            /*
            if (selection.gameObject.GetComponent<Rigidbody>().isKinematic)
            {
                print("MY rigidbody before: " + selection.gameObject.GetComponent<Rigidbody>().isKinematic);
                selection.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                print("MY rigidbody after: " + selection.gameObject.GetComponent<Rigidbody>().isKinematic);

             normal zombie does not have yet the new logic for disabling kinematic
            }
            */
            curObject.GetComponent<NavMeshAgent>().enabled = false;
            curObject.GetComponent<NavMeshObstacle>().enabled = true;

           


        }
    }

    /*
    private void manageSurvivor(Transform selection)
    {
        if (!isSurvivorActive)
        {
            Debug.Log("Collider name: " + interactableSurvivorChild.name);

            var isAgent = interactableSurvivorChild.GetComponent<NavMeshAgent>().enabled ? true : false;
            Debug.Log("isAgent: " + isAgent);
            interactableSurvivorChild.GetComponent<NavMeshObstacle>().enabled = false;

            interactableSurvivorChild.GetComponent<NavMeshAgent>().enabled = true;
            selection.GetComponent<Rigidbody>().isKinematic = true;
            //selection.GetComponent<NavMeshAgent>().destination = target.position;


            var script = interactableZombieChild.GetComponent<zombieScript>();
            script.enabled = true;
            StartCoroutine(SwitchToFinalTarget(true));



        }
        else
        {
            Debug.Log("Collider name2: " + interactableZombieChild.name);

            var isAgent = interactableZombieChild.GetComponent<NavMeshAgent>().enabled ? true : false;
            if (isAgent)
            {
                Debug.Log("isAgent2: " + isAgent);

                interactableZombieChild.GetComponent<NavMeshAgent>().isStopped = true;
                interactableZombieChild.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
                interactableZombieChild.GetComponent<Animator>().Play("Z_Idle");
                interactableZombieChild.GetComponent<NavMeshAgent>().enabled = false;
                interactableZombieChild.GetComponent<NavMeshObstacle>().enabled = true;
                selection.GetComponent<Rigidbody>().isKinematic = false;
                var script = interactableZombieChild.GetComponent<zombieScript>();
                script.enabled = false;
                StartCoroutine(SwitchToFinalTarget(false));
            }

        }
    }
    */



}
