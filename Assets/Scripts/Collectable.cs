using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 10.0f;
    public float startFollowDistance = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        GameObject player = GameObject.FindWithTag("PlayerBall");
        if (player)
        {
            if (Vector3.Distance(GameObject.FindWithTag("PlayerBall").transform.position, transform.position) < startFollowDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            } if(Vector3.Distance(GameObject.FindWithTag("PlayerBall").transform.position, transform.position) < 1.0f)
            {
                Destroy(gameObject);
            }
        }
        
	}
}
