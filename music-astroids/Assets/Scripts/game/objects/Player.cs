using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using game.objects;


namespace game.objects.player {
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
                    Instantiate(bullet, (transform.up * 0.5f) + transform.position, transform.rotation);
                    lastShot = now;
                }
            }

            if (rb.velocity.magnitude < 7) {
                if (Input.GetButton("Foward")) {
                    transform.Translate(0, 0.07f, 0);
                }
                if (Input.GetButton("Backwards")) {
                    transform.Translate(0, -0.07f, 0);
                }
            }
            if (Input.GetButton("Left")) {
                transform.Rotate(new Vector3(0, 0, 200f), 160 * Time.deltaTime, Space.Self);
            }
            if (Input.GetButton("Right")) {
                transform.Rotate(new Vector3(0, 0, -20f), 160 * Time.deltaTime, Space.Self);
                //transform.Rotate(Vector3.forward, -160 * Time.deltaTime);
            }
        }
    }
}