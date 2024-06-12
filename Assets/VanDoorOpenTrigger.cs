using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanDoorOpenTrigger : MonoBehaviour
{
    public Animator targetAnimator;
    public bool reachedVehicle = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reachedVehicle = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reachedVehicle = false;
        }
    }

    void Update()
    {
        if (reachedVehicle)
        {
            targetAnimator.SetBool("ApproachedVehicle", true);
        }
        else
        {
            targetAnimator.SetBool("ApproachedVehicle", false);
        }
    }
}