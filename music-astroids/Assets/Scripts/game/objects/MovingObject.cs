using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game.objects {
    public class MovingObject : MonoBehaviour {


        public Rigidbody2D rb;

        public void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update() {
            if (transform.position.x > 7.25f) {
                transform.Translate(-14.5f, 0, 0, Space.World);
            }
            if (transform.position.x < -7.25f) {
                transform.Translate(14.5f, 0, 0, Space.World);
            }
            if (transform.position.y > 5.5f) {
                transform.Translate(0, -11, 0, Space.World);
            }
            if (transform.position.y < -5.5f) {
                transform.Translate(0, 11, 0, Space.World);
            }
        }

    }
}
