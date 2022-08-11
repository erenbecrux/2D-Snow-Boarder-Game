using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] AudioClip crashSFX;
    bool isAlive = true;


    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag=="Ground" && isAlive)
        {
            Debug.Log("Ouch I hit my head!");
            FindObjectOfType<PlayerController>().DisableControls();
            crashParticle.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            isAlive = false;
            Invoke("ReloadScene",delayTime);
            

        }

    }
    
}
