using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;


namespace Assets.Scripts {
    public class Asteroid : MovingObject {

        public GameObject asteroid;

        new void Start() {
            ((MovingObject) this).Start();
            rb.AddForce(transform.up * 9f);
        }

        public void setMass(int mass) {
            rb.mass = mass;
        }

        new void Update() {
            ((MovingObject) this).Update();
        }

        public void Exploded() {
            if (rb.mass < 0.05f) {
                DestroyImmediate(gameObject);
            }
        }
    }
}
