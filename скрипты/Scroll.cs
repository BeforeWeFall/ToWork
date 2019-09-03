using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    [SerializeField] private float scrollSpeed;
    [SerializeField] private float size;
    [SerializeField] private Transform currobject;
    // Use this for initialization
    void Start ()
    {
        currobject = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        currobject.position = new Vector3
        (
           currobject.position.x,
           currobject.position.y,
           Mathf.Repeat(Time.time * scrollSpeed, size)
        );
        
	}
}
