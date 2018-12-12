using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_SystemRotation : MonoBehaviour {
    GameObject sun;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(sun.transform.position, sun.transform.up, (Random.Range(-50, 50)*Time.deltaTime));
	}
}
