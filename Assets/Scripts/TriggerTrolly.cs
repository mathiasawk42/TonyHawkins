using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrolly : MonoBehaviour
{
    [SerializeField]
    private GameObject trolly;
    private FollowSpline splineScript;
    private bool stateReady;

    void Start()
    {
        splineScript = trolly.GetComponent<FollowSpline>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") 
        {
            splineScript.play=true;
            foreach(Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
        }
    }

    
}
