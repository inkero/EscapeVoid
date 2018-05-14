using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWall : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 10.0f;
    public Vector3 patrolEndPosition = new Vector3(0.0f, 10.0f, 0.0f);

    private Vector3 initialPos;
    private Vector3 targetPos;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        initialPos = rb.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        float step = moveSpeed * Time.deltaTime;
        if (transform.position == initialPos) {
            targetPos = initialPos + patrolEndPosition;
        } else if(transform.position == (initialPos + patrolEndPosition))
        {
            targetPos = initialPos;
        }
        rb.transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
    }
}
