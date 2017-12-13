using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


namespace Assets.Scripts {
    public class Player : MovingObject {
        public float thrust = 3f;
        public GameObject bullet;
        private float lastShot = 0f;


        // Update is called once per frame
        new void Update() {
            ((MovingObject) this).Update();
            if (Input.GetButton("Fire1")) {
                float now = Time.time;
                if (now - lastShot >= 0.12f) {
                    Instantiate(bullet, (transform.up * 1.4f) + transform.position, transform.rotation);
                    lastShot = now;
                }

            }

            if (rb.velocity.magnitude < 7) {
                if (Input.GetButton("Foward")) {
                    rb.AddForce(transform.up * thrust);
                }
            }
            if (Input.GetButton("Left")) {
                transform.Rotate(Vector3.forward, 160 * Time.deltaTime);
            }
            if (Input.GetButton("Right")) {
                transform.Rotate(Vector3.forward, -160 * Time.deltaTime);
            }
        }
    }
}