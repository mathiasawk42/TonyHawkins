using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSliders : MonoBehaviour
{
    private GameObject door1, door2;
    private Vector3 doorPos1, doorPos2;
    private float z1Close, z2Close, z1Open, z2Open;
    private float openDistance = 0.75f;
/*
    void Start()
    {
        door1 = gameObject.transform.GetChild(0).transform;
        door2 = gameObject.transform.GetChild(1).transform;
        doorPos1 = door1.positon;
        doorPos2 = door2.position;
        z1Close = doorPos1.z;
        z2Close = doorPos2.z;
        z1Open = z1Close - openDistance;
        z2Open = z2Close + openDistance;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        StartCoroutine(SlideDoor(doorPos1, z1Close));
    }

    public void CloseDoor()
    {

    }


    public IEnumerator SlideDoor(Vector3 startPos, Vector3 endPos)
    {   
        var t = 0f;
        start = startPos;
        target = endPos;

        while (t < 1)
        {
            t += Time.deltaTime / TempoSalita;

            if (t > 1) t = 1;

            transform.position = Vector3.Lerp(start, target, t);

            yield return null;
        }
    }

*/




}
