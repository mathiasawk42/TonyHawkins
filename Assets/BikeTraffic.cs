using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Pixelplacement.TweenSystem;

public class BikeTraffic : MonoBehaviour
{
    private float nextActionTime = 0.0f;
    public float Frequency;
    public Spline spline;
    public GameObject bike;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime) 
        { 
            nextActionTime = Time.time + (Frequency * Random.Range(0f,2f));
            GameObject b = Instantiate(bike,this.transform);
            Tween.Spline (spline, b.transform, 0, 1, true, speed, 0, Tween.EaseLinear, Tween.LoopType.None, HandleTweenStarted, () => Destroy(b.gameObject));

        } 
        
    }
    public void HandleTweenStarted()
	{
        
	}
}
