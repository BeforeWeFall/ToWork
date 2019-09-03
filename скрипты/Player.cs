using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    [SerializeField] private float speed = 5;
    [SerializeField] private float xMax, xMin;
    [SerializeField] private float incline;
    [SerializeField] private float rateShoot=0.5f;
    [SerializeField] private float nextShoot =0.0f;
    [SerializeField] private float hp;

    private GameController gameController;
    [SerializeField] private Text hpText;
    public GameObject shoot;
    public Transform shootSpawn;

    public void Start()
    {
        GameObject GameControllerFind = GameObject.FindWithTag("GameController");
        if (GameControllerFind != null)
        {
            gameController = GameControllerFind.GetComponent<GameController>();
        }
    }

    public void Dmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
            gameController.GameOver();
        }
    }

    // Use this for initialization
    void Update ()
    {
		if(Input.GetButton("Fire1") && Time.time > nextShoot)
        {
            nextShoot = Time.time + rateShoot;
            Instantiate(shoot, shootSpawn.position, shootSpawn.rotation);
        }
        hpText.text = "HP : " + hp; 

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody>().velocity = new Vector3(moveHorizontal, 0.0f, 0.0f) * speed;
        GetComponent<Rigidbody>().position = new Vector3
            (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, xMin, xMax),
            0.0f,
            0.0f
            );

        GetComponent<Rigidbody>().rotation = Quaternion.Euler
            (0.0f,
            0.0f,
            GetComponent<Rigidbody>().velocity.x * -incline);
	}
}
