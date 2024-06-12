using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrossLight : MonoBehaviour
{
    private GameObject walkLight, stopLight;
    void Start()
    {
        stopLight = this.gameObject.transform.GetChild(0).gameObject;
        walkLight = this.gameObject.transform.GetChild(1).gameObject;  
    }

    public void ChangeLight(bool lightState)
    {
        walkLight.SetActive(lightState);
    }

}
