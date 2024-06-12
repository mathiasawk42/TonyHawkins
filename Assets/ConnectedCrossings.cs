using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectedCrossings : MonoBehaviour
{
    public CrossLight[] crossLights;
    private float period = 17.5f;
    public bool RedLight;
    public TraficLightBehavior[] crossings;

    void Start()
    {
        InvokeRepeating("RedLightTiming", 10.0f, period);
    }

    void Update()
    {
        foreach(TraficLightBehavior e in crossings)
        {
            e.isRed = RedLight;
        }
    }

    void RedLightTiming()
    {
        RedLight = !RedLight;
        foreach(CrossLight l in crossLights)
        {
            l.ChangeLight(RedLight);
        }
    }

}
