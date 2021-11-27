using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SurvivorScript : MonoBehaviour
{
    // Get transform properties for targets
    private Transform finalTarget;
    public Transform initTarget;
    // current survivor agent
    NavMeshAgent survivor;
    // keep status of targets
    private bool isFinalTarget;
    private bool isClostToTarget;
    // keep status of survivor
    public static bool survivorChased;
    // Triggering object
    private GameObject cubicle;
    private bool isFirsTime = true;
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
        // update transform properties
        initTarget = initTarget.transform;
        finalTarget = marioPlayer.transform;
        // get current agent properties
        survivor = this.GetComponent<NavMeshAgent>();
        // get triggering object
        cubicle = GameObject.FindWithTag("TargetCube");
    }

    // Update is called once per frame
    void Update()
    {
        // Validate proximity to change destination for survivor

        if (survivor.enabled)
        {
            if (CheckProximityToCamera(3, cubicle) || isFinalTarget)
            {
                isFinalTarget = true;
                StartCoroutine(SwitchToFinalTarget());
            }
            else
            {
                // Survivor initial destination
                survivor.SetDestination(initTarget.position);
                // check proximity and handle animations
                if (CheckProximityToInitialTarget(1) && !isFinalTarget)
                {
                    print("Iam home");
                    survivor.GetComponent<Animator>().Play("Z_Walk1_InPlace");
                    survivorChased = true;
                }
                else
                {
                    survivor.GetComponent<Animator>().Play("Z_Run");
                    print("First trigger of Running");
                    survivorChased = true;
                }
            }
        }
       

    }

    // Check proximity between camera and obj
    private bool CheckProximityToCamera(int distance, GameObject obj)
    {
        if ((marioPlayer.transform.position - obj.transform.position).sqrMagnitude <= distance * distance)
        {            
            print("Close to Cubicle");
            return true;
        }
        return false;
    }

    // Check distance against Camera
    private bool CheckProximity(int distance)
    {
        if ((marioPlayer.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {
            isClostToTarget = true;
            return true;
        }
        return false;
    }

    // Check proximity against initial obj
    private bool CheckProximityToInitialTarget(int distance)
    {
        if ((initTarget.transform.position - this.transform.position).sqrMagnitude <= distance * distance)
        {            
            return true;
        }
        return false;
    }

    // Coroutine handles changes destination for survivor
    IEnumerator SwitchToFinalTarget()
    {
        if (isFirsTime)
        {
            yield return new WaitForSeconds(15);
            isFirsTime = false;
        }

        if (survivor.enabled)
        {
            // Survivor destination is now Camera's position
            survivor.SetDestination(finalTarget.position);

            // Handle animations based on proximity
            if (CheckProximity(2) || CheckProximity(3) || CheckProximity(1))
            {
                print("Im close to camera");
                survivor.GetComponent<Animator>().Play("Z_Walk1_InPlace");
                survivorChased = true;
            }
            else
            {
                survivor.GetComponent<Animator>().Play("Z_Run");
                print("Iam far from Camera 2");
                survivorChased = true;
            }
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
