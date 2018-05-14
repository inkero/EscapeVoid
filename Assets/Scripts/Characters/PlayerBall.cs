using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerBall : MonoBehaviour {

    public float moveForce = 5;
    public Respawning respawningObject;
    public AudioClip collectSound;
    public AudioClip spawnSound;
    public GameObject deathEffectPrefab;

    private Rigidbody rb;
    private AudioSource audioSource;
    private Animation anim;

    // Use this for initialization
    void Awake () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animation>();

        respawningObject = GameObject.FindWithTag("MainCamera").GetComponent<Respawning>();
        audioSource.PlayOneShot(spawnSound);
        anim.Play("Spawn");
    }

    private void FixedUpdate()
    {
            Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * moveForce;
            rb.AddForce(moveVec, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "KillWall")
        {
            GameObject deathEffect = Instantiate(deathEffectPrefab, gameObject.transform.position, gameObject.transform.rotation);
            respawningObject.respawnMe();
            Destroy(deathEffect, 2.0f);
            Destroy(gameObject);

            //rb.transform.position = new Vector3(0, 0, 0);
           
        }

        if(other.tag == "Collectable")
        {
            audioSource.PlayOneShot(collectSound);
            respawningObject.AddScore(1);
        }

        if(other.tag == "SpawnPoint")
        {
            respawningObject.currentSpawnPoint = other.transform;
        }
    }


}
