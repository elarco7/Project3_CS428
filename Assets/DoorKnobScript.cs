using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorKnobScript : MonoBehaviour
{
    
    public AudioSource doorOpening;
    public GameObject interactableSurvivorZombieAgent;
    public GameObject interactableSurvivor;
    public GameObject interactableFirstCrawler;
    public GameObject interactableCopyCrawler;
    private bool isReset;
    private bool isSurvivorReset;    
    Vector3 location;
    Vector3 survivorLocation;

    // Start is called before the first frame update
    void Awake()
    {
        
       
    }

    private void Update()
    {

        if (!isReset && !SurvivorScript.survivorChased)
        {
            isReset = false;
            location = interactableFirstCrawler.transform.position;
            interactableFirstCrawler.SetActive(false);
            interactableCopyCrawler.transform.position = location;
            interactableCopyCrawler.SetActive(true);
            isReset = true;
        }            
        
    }


    private void OnTriggerEnter(Collider other)
    {
        
        doorOpening.Play();
        StartCoroutine(SwitchToFinalTarget());
        print("Touching the doorknob");
    }

    IEnumerator SwitchToFinalTarget()
    {
        
        yield return new WaitForSeconds(10);
        survivorLocation = interactableSurvivor.transform.position;
        interactableSurvivor.SetActive(false);
        yield return new WaitForSeconds(2);
        SurvivorScript.survivorChased = false;
        if (!isSurvivorReset)
        {
            resetSurvivor();
        }
       // survivorZombieAgent.SetActive(true);
        print("Crawler should target CAMERA NOW");
       

    }

    void resetSurvivor()
    {
        interactableSurvivorZombieAgent.transform.position = survivorLocation;
        interactableSurvivorZombieAgent.SetActive(true);
        isSurvivorReset = true;
    }

    
}
