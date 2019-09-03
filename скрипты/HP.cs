using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour {
    [SerializeField] private float hp;

    public void Dmg(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
