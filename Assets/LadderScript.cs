using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject ladderObject;
    public GameObject grabbableLadder;
    private bool isLadderActive;
    Vector3 grabbablePosition;
    Quaternion ladderRotation;
    Vector3 ladderPosition;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        grabbablePosition = grabbableLadder.transform.position;
        ladderRotation = ladderObject.transform.rotation;
        ladderPosition = ladderObject.transform.position;
        isLadderActive = ladderObject.activeInHierarchy;
       
    }

    public void enableLadder()
    {
        
        grabbableLadder.SetActive(false);
        ladderObject.SetActive(true);
               
        
    }

    
    public void disableLadder()
    {
        grabbableLadder.transform.position = ladderPosition;
        //grabbableLadder.transform.rotation = ladderRotation;

        ladderObject.SetActive(false);
        grabbableLadder.SetActive(true);
        grabbableLadder.GetComponent<Rigidbody>().useGravity = true;
        grabbableLadder.GetComponent<Rigidbody>().isKinematic = false;


    }
    
    
    

    private GameObject getObjectChildren()
    {
        var firstChild = ladderObject.transform.GetChild(0);
        var secondChild = firstChild.transform.GetChild(0);
        var thirdChild = secondChild.transform.GetChild(1);
        var fourChild = thirdChild.transform.GetChild(2);
        var fifthChild = fourChild.transform.GetChild(3);
        
        return fifthChild.gameObject;
    }

    private GameObject getOutputChildren()
    {
        var firstChild = ladderObject.transform.GetChild(1);
        return firstChild.gameObject;
    }




}
