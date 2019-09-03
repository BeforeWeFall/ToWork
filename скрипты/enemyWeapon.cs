using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyWeapon : MonoBehaviour {

    [SerializeField] private GameObject shoot;
    [SerializeField] private Transform[] shotSpawn;
    [SerializeField] private float fireRate;
    [SerializeField] private float delay;
    
    // Use this for initialization
    void Start () {
        InvokeRepeating("Fire", delay, fireRate);
	}
	
	// Update is called once per frame
	void Fire() {
        for(int i = 0; i < shotSpawn.Length; i++)
        {
            Instantiate(shoot, shotSpawn[i].position, shotSpawn[i].rotation);
        }
        
	}
}
