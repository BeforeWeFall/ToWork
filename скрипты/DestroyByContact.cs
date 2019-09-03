using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    [SerializeField] private int dmg;
    [SerializeField] private int scoreValue;
    private GameController gameController;

    public void Start()
    {
        GameObject GameControllerFind = GameObject.FindWithTag("GameController");
        if (GameControllerFind != null)
        {
            gameController = GameControllerFind.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") // переделать на хп
        {
            other.GetComponent<Player>().Dmg(dmg);
            Destroy(gameObject);
            
        }
        if (other.tag == "Bolt")
        {
            GetComponent<HP>().Dmg(1);
            Destroy(other.gameObject);

            gameController.NewScore(scoreValue);
        }
    }
}
