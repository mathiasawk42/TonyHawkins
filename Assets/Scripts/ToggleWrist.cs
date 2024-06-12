using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleWrist : MonoBehaviour
{
    private GameObject wristUI;
    private CanvasGroup wristCanvas;
    private float canvasAlpha = 0f;
    private float yPosTreshold = 1.115f;
    private float yRotTreshold = 0f;
    private bool fadeIn = true;

    private float fadeSpeed = 2.5f; 

    void Start()
    {
        wristUI = this.gameObject.transform.GetChild(1).gameObject; 
        wristCanvas = wristUI.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.localPosition.y >= yPosTreshold)
        {
            wristCanvas.alpha = transform.localPosition.y-0.04f;
        }
        else if(transform.localPosition.y < yPosTreshold)
        {
            wristCanvas.alpha = transform.localPosition.y-0.775f;
        }
    }
}
