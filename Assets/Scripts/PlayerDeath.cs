using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerDeath : MonoBehaviour
{

    public GameObject Fader;
    public AudioSource crashSound;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine("ReloadLevel");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car" | other.tag== "Bike") 
        {
            Debug.Log("Hit by car");
            StartCoroutine("ReloadLevel");


        }
        
    }
    IEnumerator ReloadLevel()
    {
        crashSound.Play();
        Fader.SetActive(true);
        Debug.Log("Coroutine Running");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("CarTestScene");
      
    }

    
}
