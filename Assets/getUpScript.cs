using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getUpScript : MonoBehaviour
{
    // current zombie on laying on the floor
    public GameObject floorZombie;
    // zombie that will replace floorZombie
    public GameObject newInteractableZombie;
    // status for zombie
    private bool setZombie = false;


    void Start()
    {
        // Just set their conditions as obstacles to true
        //zombieEating.GetComponent<NavMeshObstacle>().enabled = true;
        //zombieEating2.GetComponent<NavMeshObstacle>().enabled = true;
        // Coroutine will start once condition is met
        //StartCoroutine(activateFloorZombie());
    }


    // Update is called once per frame
    void Update()
    {
      
        
        // Access variable in dualModeZombie and check value
        if (dualModeZombie.isUp && !setZombie)
        {
            // change status for zombie
            setZombie = true;
            // call to coroutine
            StartCoroutine(activateFloorZombie());
        } 
        
    }

    // Coroutine will enable new agent and disable current zombie
    IEnumerator activateFloorZombie()
    {

        //yield return new WaitUntil(zombieIsUp);
        yield return new WaitForSeconds(10);
        floorZombie.SetActive(false);
        newInteractableZombie.SetActive(true);

    }

    private bool zombieIsUp()
    {
        if (dualModeZombie.isUp)
            return true;
        else
            return false;
    }
}
