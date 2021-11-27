using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableLadderScript : MonoBehaviour
{

    public GameObject ladderObject;
    public GameObject grabbableLadder;
  
    private bool isGrabbableActive;

    Vector3 ladderPosition;
    Vector3 grabbablePosition;
    Quaternion grabbableRotation;
    
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        ladderPosition = ladderObject.transform.position;
        grabbableRotation = grabbableLadder.transform.rotation;
        grabbablePosition = grabbableLadder.transform.position;
        isGrabbableActive = grabbableLadder.activeInHierarchy;
        
    }

    public void enableLadder()
    {
        
        ladderObject.SetActive(false);
        grabbableLadder.SetActive(true);
    }

    public void disableLadder()
    {
        ladderObject.transform.position = grabbablePosition;
        //ladderObject.transform.rotation = grabbableRotation;
        grabbableLadder.SetActive(false);
        ladderObject.SetActive(true);
        ladderObject.GetComponent<Rigidbody>().useGravity = false;
        ladderObject.GetComponent<Rigidbody>().isKinematic = true;

    }
}
