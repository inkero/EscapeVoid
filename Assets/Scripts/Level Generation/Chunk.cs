using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    //public int destroyDelay = 5;
    //private float timer;

    public bool hasSpawnedChunk = false;
    public GameObject blocker;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Void")
        {
            Destroy(gameObject);
        }

        if(other.tag == "PlayerBall"){
            blocker.SetActive(true);
        }
    }

    /*
	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "PlayerBall"){
            StopTimer();
            ResetTimer();
        }
	}   
	
	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "PlayerBall")
        {
            StartTimer();
        }
	}

	private void StartTimer(){
        InvokeRepeating("RunTimer", 1.0f, 1.0f);
    }

    private void StopTimer(){
        CancelInvoke();
    }

    private void ResetTimer(){
        timer = 0;
    }

    private void RunTimer(){
        timer += 1;

        if (timer >= destroyDelay)
        {
            DestroyChunk();
        }
    }

    private void DestroyChunk(){
        Destroy(gameObject);
    }
    */
}