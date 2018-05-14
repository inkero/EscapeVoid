using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    private float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time = time - Time.deltaTime;
        Debug.Log(time);
		if(time <= 0)
        {
            Destroy(gameObject);
        }
	}
}
