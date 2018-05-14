using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour {

    public GameObject[] chunks;

	private void OnTriggerEnter(Collider other)
	{
        if(other.tag == "EndPoint" && !other.GetComponentInParent<Chunk>().hasSpawnedChunk){
            int randomInt = (int)Random.Range(0, chunks.Length);
            Debug.Log(randomInt);
            GameObject newChunk = Instantiate(chunks[randomInt], other.transform.position, other.transform.rotation, null);
            other.GetComponentInParent<Chunk>().hasSpawnedChunk = true;
        }
	}
}
