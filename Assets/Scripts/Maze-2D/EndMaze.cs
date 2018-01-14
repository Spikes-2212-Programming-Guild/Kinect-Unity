using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMaze : MonoBehaviour {
    public GameObject Player;
    // Use this for initialization
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject == Player)
            Application.LoadLevel(2);
    }
}

