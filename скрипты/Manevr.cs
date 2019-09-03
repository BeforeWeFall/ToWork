using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manevr : MonoBehaviour {


    public Vector2 manevrTime;
    public Vector2 manevrWate;
    public Vector2 startWait;
    public float dodge;
    private float targetManeuver;
    public float manevrSpeed;
    private float currentSpeed;
    [SerializeField] public float xMax, xMin, zMin, zMax;
    [SerializeField] private float incline;
    // Use this for initialization
    void Start () {
        currentSpeed = GetComponent<Rigidbody>().velocity.z;
        StartCoroutine(Evade());
	}

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            yield return new WaitForSeconds(Random.Range(manevrTime.x, manevrTime.y));

            targetManeuver = 0;

            yield return new WaitForSeconds(Random.Range(manevrWate.x, manevrWate.y));
        }
        
        
    }

    // Update is called once per frame
    void FixedUpdate () {

        float newManevr = Mathf.MoveTowards
            (
            GetComponent<Rigidbody>().velocity.x,
            targetManeuver,
            manevrSpeed * Time.deltaTime
            );
        GetComponent<Rigidbody>().velocity = new Vector3(newManevr, 0, currentSpeed);

        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
            0.0f,
             Mathf.Clamp(GetComponent<Rigidbody>().position.z, zMin, zMax) 
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler
            (0,
            0,
            GetComponent<Rigidbody>().velocity.x * -incline); //поправить
    }
}
