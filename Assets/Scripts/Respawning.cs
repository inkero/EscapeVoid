using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawning : MonoBehaviour {

    public CameraFollow mainCamera;
    public GameObject playerBall;
    public AudioClip deathSound;
    public Text scorePrefab;
    public Text winScreenTextPrefab;
    public int score = 0;
    public Transform currentSpawnPoint;

    private AudioSource audioSource;
    private IEnumerator coroutine;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int amount)
    {
        score = score + amount;
        scorePrefab.text = "Score: " + score;
        winScreenTextPrefab.text = "YOU WON! YOUR SCORE: " + score;
    }

    public void respawnMe()
    {
        audioSource.PlayOneShot(deathSound);
        mainCamera.target = null;

        coroutine = WaitAndSpawn(2.0f);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitAndSpawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        GameObject newPlayerBall = Instantiate(playerBall, currentSpawnPoint.position, currentSpawnPoint.rotation, null);

        mainCamera.target = newPlayerBall.transform;
    }
}
