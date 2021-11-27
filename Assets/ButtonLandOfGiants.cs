using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLandOfGiants : MonoBehaviour
{
    public GameObject[] Scenes;
    //public GameObject backLight;
    private Scene scene;
    private static GameObject currentScene;
    private bool isActive;
    private static int newSceneIndex;
    private static int oldSceneIndex;
    private static bool isColliding = true;
    private static bool isRoutine = false;
    private static bool isExited = true;
    private static Coroutine routine;

    // Start is called before the first frame update
    private void Awake()
    {
        Scenes[0].SetActive(true);
        foreach (var sc in Scenes)
        {
            print(sc.name);
        }
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
            if (isExited)
            {
                if (!isActive)
                {
                    var num = 0;
                    foreach (var sc in Scenes)
                    {
                        if (sc.name != scene.name)
                        {

                            sc.SetActive(false);
                            if (sc.name != "BlackScreen")
                                sc.GetComponent<BoxCollider>().enabled = false;
                            num++;
                            print("1: " + num);
                        }
                        else
                        {
                            print("Else: " + sc.name);
                            Scenes[0].SetActive(false);

                            sc.SetActive(true);
                            sc.GetComponent<BoxCollider>().enabled = true;
                            oldSceneIndex = num;
                            newSceneIndex = num + 1;
                            print("2: " + oldSceneIndex);
                            isExited = false;
                           
                        }
                    }
                }
                else
                {
                    print("ActiveTrue: " + Scenes[oldSceneIndex]);
                    print("ISRoutine: " + isRoutine);
                    if (isRoutine)
                    {
                        isColliding = true;
                        StopCoroutine(routine);
                    }
                    print("OldIndex: " + oldSceneIndex);
                    newSceneIndex = newSceneIndex % Scenes.Length;
                    print("newIndexAfter %: " + newSceneIndex);
                    if (newSceneIndex == 0)
                        newSceneIndex += 1;

                    Scenes[oldSceneIndex].SetActive(false);
                    Scenes[oldSceneIndex].GetComponent<BoxCollider>().enabled = false;
                    Scenes[newSceneIndex].SetActive(true);
                    Scenes[newSceneIndex].GetComponent<BoxCollider>().enabled = true;
                    oldSceneIndex = newSceneIndex;
                    isExited = false;
                    print("oldIndexBeforeExitFunction %: " + oldSceneIndex);
                    newSceneIndex += 1;
                    print("newIndexBeforeExitFunction : " + newSceneIndex);



                }
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        print("Index: " + oldSceneIndex);
        print("Exit: " + Scenes[oldSceneIndex]);
        isActive = true;
        isColliding = false;
        isExited = true;
        routine = StartCoroutine(SwitchToFinalTarget());
    }



    IEnumerator SwitchToFinalTarget()
    {
        print("CoroutineStart: " + Scenes[oldSceneIndex]);
        isRoutine = true;
        yield return new WaitForSeconds(7);
        print("RIGHTAFTER YIELD: " + isColliding);

        if (!isColliding)
        {
            print("CoroutineAfterYield: " + Scenes[oldSceneIndex]);
            foreach (var sc in Scenes)
            {
                if (sc.name != "BlackScreen")
                {
                    sc.SetActive(false);
                    sc.GetComponent<BoxCollider>().enabled = false;
                }
                else
                {
                    sc.SetActive(true);
                }
            }

            isColliding = true;
            isActive = false;
            isRoutine = false;
            print("AfterISColliding: " + oldSceneIndex);
        }
        print("AfterXX: " + oldSceneIndex);

    }
}
