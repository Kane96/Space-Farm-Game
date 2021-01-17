using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometScript : MonoBehaviour {

    void die()
    {
        Destroy(transform.parent.gameObject);
        Destroy(gameObject);
    }
}
