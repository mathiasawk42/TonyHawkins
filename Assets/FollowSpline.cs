using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Pixelplacement.TweenSystem;

public class FollowSpline : MonoBehaviour
{
    public Spline spline;
    public float duration;
    public bool play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            begin();
            play = false;
        }
    }

    void begin()
    {
        TweenBase tween = Tween.Spline(spline, this.transform,0,1,true, duration, 0,Tween.EaseOut, Tween.LoopType.None);
    }
}
