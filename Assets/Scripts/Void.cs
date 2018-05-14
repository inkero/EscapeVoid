using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour {

    private Rigidbody rb;
    public float followSpeed;

	private void Start()
	{
        rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	private void Update () {
        GameObject player = GameObject.FindWithTag("PlayerBall");
        if(player){
            float step = followSpeed * Time.deltaTime;
            Vector3 playerPosXY = new Vector3(0.0f, 0.0f, transform.position.z);
            playerPosXY.x = player.transform.position.x;
            playerPosXY.y = player.transform.position.x;
            transform.position = Vector3.MoveTowards(transform.position, playerPosXY, step);
        }
	}

	private void OnTriggerExit(Collider other)
	{
	}
}
