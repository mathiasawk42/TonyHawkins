using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Pixelplacement.TweenSystem;

public class TraficLightBehavior : MonoBehaviour
{
    public List<CarAnim> cars = new List<CarAnim>();
    public List<Material> mat =  new List<Material>();
    public bool isRed;
    public  float speed;
    private bool prevFrame;
    private float nextActionTime = 0.0f;
    public float Frequency;
    public float SlowDownSpeed;
    public Spline spline;
    public Spline splineStop;
    private bool Stopped;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime && !Stopped) 
        { 
            nextActionTime = Time.time + Frequency;
            CarAnim car = Instantiate(cars[Random.Range(0,cars.Count)],this.transform);
            car.GetComponent<MeshRenderer>().material = mat[Random.Range(0,mat.Count)];
            car.tween = Tween.Spline (spline, car.transform, 0, 1, true, speed, 0, Tween.EaseIn, Tween.LoopType.None, car.HandleTweenStarted, car.HandleTweenFinished);

        } 
        else if (Stopped)
        {
            nextActionTime += Time.deltaTime;
        }

        if (isRed && isRed != prevFrame)
        {
            foreach (CarAnim car in this.GetComponentsInChildren<CarAnim>())
            {
                if(!car.Crossed)
                {
                    float temPos = splineStop.ClosestPoint(car.transform.position);
                    car.speed = speed;
                    car.tween = Tween.Spline (splineStop, car.transform, temPos, 1, true, SlowDownSpeed*(1-temPos), 0, Tween.EaseOut, Tween.LoopType.None, car.HandleTweenStarted, StopAllCars);
                }
            }
        }
        else if (!isRed && isRed != prevFrame)
        {
            StartAllCars();
        }
        prevFrame = isRed;
    }

    void StopAllCars()
    {
        Stopped = true;
        foreach (CarAnim car in this.GetComponentsInChildren<CarAnim>())
        {
            if(!car.Crossed)
            {
                car.tween.Stop();
            }
        }
    }
    void StartAllCars()
    {
        Stopped = false;
        foreach (CarAnim car in this.GetComponentsInChildren<CarAnim>())
        {
            float temPos = spline.ClosestPoint(car.transform.position);
            car.tween = Tween.Spline (spline, car.transform, temPos, 1, true, speed*(1-temPos), Mathf.Max(2.5f-(temPos*10),0), Tween.EaseIn, Tween.LoopType.None, car.HandleTweenStarted, car.HandleTweenFinished);
        }
        nextActionTime += 3f;
    }
}
