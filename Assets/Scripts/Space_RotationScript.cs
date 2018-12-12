using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space_RotationScript : MonoBehaviour {



    //Rotation Speed
    public float RotationSpeed;


    // Use this for initialization
    void Start () {
        RotationSpeed = Random.Range(-5f, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        //This snippet was taken from XSSA on Unity Forums
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
}
