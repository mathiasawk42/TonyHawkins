using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralChair : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y ,transform.localEulerAngles.z);
    }
}
