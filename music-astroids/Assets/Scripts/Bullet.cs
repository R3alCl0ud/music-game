using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public Rigidbody2D rb;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * 500f);
    }

    private void Update() {
        if (!gameObject.GetComponent<Renderer>().isVisible) {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D coll) {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Asteroid") {
            coll.gameObject.SendMessage("Exploded");
        }
    }
}
