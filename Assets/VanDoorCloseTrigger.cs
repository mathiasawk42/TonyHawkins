using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanDoorCloseTrigger : MonoBehaviour
{

    public Animator targetAnimator;
    public bool isInside = false;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInside = true;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInside = false;
        }
    }

    void Update()
    {
        if (isInside)
        {
            targetAnimator.SetBool("EnteredVehicle", true);
        }
        else
        {
            targetAnimator.SetBool("EnteredVehicle", false);
        }
    }
}