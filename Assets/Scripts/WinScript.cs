using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour {

    public GameObject winScreen;
    public AudioClip winSound;
    public AudioClip winSound2;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerBall")
        {
            winScreen.SetActive(true);
            audioSource.PlayOneShot(winSound);
            audioSource.PlayOneShot(winSound2);
        }
    }
}
