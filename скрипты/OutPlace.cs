using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutPlace : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
