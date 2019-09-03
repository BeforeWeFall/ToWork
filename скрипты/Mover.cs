using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    [SerializeField] private float speed;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
