using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public Color spriteColor;
    [SerializeField] float FadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spriteColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        spriteColor.a += FadeSpeed;
        GetComponent<SpriteRenderer>().color = spriteColor;
    }

}
