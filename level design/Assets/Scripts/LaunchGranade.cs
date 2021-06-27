using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGranade : MonoBehaviour
{

    public Transform spawnPosition;
    public GameObject fragNade;

    public float range = 30f;

    public Rigidbody playerRb;

    private void Start()
    {

        playerRb = this.GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {

            Launch();
        }    
    }
    private void Launch()
    {
        GameObject nadeInstance = Instantiate(fragNade, spawnPosition.position, spawnPosition.rotation);
        nadeInstance.GetComponent<Rigidbody>().AddForce((spawnPosition.forward * range) + playerRb.velocity , ForceMode.Impulse);
    }
}
