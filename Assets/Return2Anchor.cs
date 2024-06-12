using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return2Anchor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool deselect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deselect == true)
        {
        transform.position = transform.parent.position;
            deselect = false;
        }
        
    }
}
