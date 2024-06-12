using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjectiveController : MonoBehaviour
{
    private List<GameObject> phaseObject = new List<GameObject>();
    private CollectUIScript collectUIScript;
    public int currentPhase = 0;
    
    public GameObject parkingDoor;

    void Start()
    {
        currentPhase = 0;
        foreach(Transform child in transform)
        {
            phaseObject.Add(child.gameObject);
        }     
        collectUIScript = phaseObject[1].GetComponent<CollectUIScript>();
        Debug.Log("Start Current Phase ="+currentPhase);
    }


    void Update()
    {
        /*
        switch (currentPhase)
        {
            case 0:
                Phase1;
                break;
            case 1:
                Phase2;
                break;
            case 2:
                Phase3;
                break;
        }*/

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Current Phase ="+currentPhase);
        } 

         if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            NextPhase();
        } 
    }


    void Phase1()
    {
        
    }

    void Phase2()
    {
    
    }

    void Phase3()
    {

    }

    public void NextPhase()
    {
        Debug.Log("Running nextPhase");
        phaseObject[currentPhase].gameObject.SetActive(false);
        currentPhase++;
        phaseObject[currentPhase].gameObject.SetActive(true);

        if(currentPhase==2)
        {
            parkingDoor.SetActive(false);
        }
    }
}
