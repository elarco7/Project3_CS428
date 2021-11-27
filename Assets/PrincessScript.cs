using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessScript : MonoBehaviour
{
    public GameObject parent;
    private GameObject marioPlayer;
    public GameObject interactableMario;
    // Start is called before the first frame update
    private void Awake()
    {
        marioPlayer = getMarioChild();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckProximity())
        {
            this.GetComponent<Animator>().Play("Excited");
        }
        else
        {
            this.GetComponent<Animator>().Play("Terrified");
        }
    }

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
