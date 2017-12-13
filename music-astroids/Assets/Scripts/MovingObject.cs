using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts {
    public class MovingObject : MonoBehaviour {


        public Rigidbody2D rb;

        public void Start() {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update() {
            if (transform.position.x > -0.25f) {
                transform.Translate(-17, 0, 0, Space.World);
            }
            if (transform.position.x < -17.5f) {
                transform.Translate(17, 0, 0, Space.World);
            }
            if (transform.position.y > 10.25f) {
                transform.Translate(0, -11, 0, Space.World);
            }
            if (transform.position.y < -0.75f) {
                transform.Translate(0, 11, 0, Space.World);
            }
        }

    }
}
