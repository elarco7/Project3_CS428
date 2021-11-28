using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest : MonoBehaviour
{
    public GameObject player;
    public Transform objL2;
    public Transform objR2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (RotateWorld.isChangeL2 || TestMark.test)
            changeToL2Position();
        else if (RotateWorld.isChangeR2)
            changeToR2Position();
    }



    void changeToL2Position()
    {
        
        player.transform.position = player.transform.position + new Vector3(objL2.position.x*5f, objL2.position.y, objL2.position.z*5f);        
        RotateWorld.isChangeL2 = false;
        TestMark.test = false;
    }

    void changeToR2Position()
    {

        player.transform.position = player.transform.position + new Vector3(objR2.position.x+3, objR2.position.y, objR2.position.z+3);
        RotateWorld.isChangeR2 = false;
        TestMark.test = false;
    }
}
