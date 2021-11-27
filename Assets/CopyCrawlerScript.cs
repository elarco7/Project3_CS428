using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyCrawlerScript : MonoBehaviour
{
    private Transform targetCam;
    public GameObject crawler;
    public AudioSource attackAudio;
    public AudioSource walkAudio;
    public AudioSource walkFastAudio;
    // Start is called before the first frame update
    void Start()
    {
        targetCam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
