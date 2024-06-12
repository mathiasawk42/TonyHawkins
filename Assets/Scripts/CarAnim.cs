using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Pixelplacement.TweenSystem;

public class CarAnim : MonoBehaviour
{
    public List<Transform> wheels = new List<Transform>();

    [HideInInspector]
    public float speed;
    [HideInInspector]
    public bool Crossed;
    [HideInInspector]
    public TweenBase tween;
    void Start()
    {
        foreach (Transform e in wheels)
        {
            Tween.LocalRotation (e, new Vector3 (90, 0, 0), speed/10, 0, Tween.EaseLinear, Tween.LoopType.Loop);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "crossing")
        {
            this.Crossed = true;
        }
    }

    public void HandleTweenStarted ()
	{
        
	}

	public void HandleTweenFinished ()
	{
		Destroy(this.gameObject);
	}
    
}
