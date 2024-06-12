using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectUIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject objectiveParent;
    private List<GameObject> objectives = new List<GameObject>();
    private int objectCount;
    private int currentCollected = 0;
    private UIObjectiveController UIObjectiveController;

    void Start()
    {
        objectiveParent = gameObject.transform.GetChild(0).gameObject;
        foreach(Transform child  in objectiveParent.transform)
        {
            objectives.Add(child.gameObject);
            objectCount++;
            Debug.Log("obj count"+objectCount);
        } 
        UIObjectiveController = transform.parent.gameObject.GetComponent<UIObjectiveController>();

    }

    void Update()
    {
        for(int i=0; i<objectives.Count;i++)
        {
            objectives[i].transform.Rotate (0,50*Time.deltaTime,0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CollectObject(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CollectObject(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CollectObject(2);
        } 
    }


    public void CollectObject(int objectIndex)
    {
        objectives[objectIndex].gameObject.transform.GetChild(0).gameObject.SetActive(false);
        currentCollected++;
        checkPhase();
    }

    void checkPhase()
    {
        if(currentCollected == objectCount)
        {
            //Complete phase
            Debug.Log("Collection Complete");
            UIObjectiveController.NextPhase();
        }
    }
}
