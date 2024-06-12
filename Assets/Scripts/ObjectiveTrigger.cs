using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public int phaseForTrigger;
    public UIObjectiveController uIObjectiveController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log(other);
        }
        if(other.tag == "Player" && uIObjectiveController.currentPhase == phaseForTrigger) {
            uIObjectiveController.NextPhase();
            foreach(Collider c in GetComponents<Collider>())
            {
                c.enabled = false;
            }
            
        }
    }
}
