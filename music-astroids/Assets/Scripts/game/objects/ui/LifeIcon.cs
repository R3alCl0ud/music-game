using System;
using UnityEngine;
using UnityEngine.UI;


namespace game.objects.ui {
    public class LifeIcon : MonoBehaviour {

        public void setPosition(Vector3 pos) {
            transform.SetPositionAndRotation(pos, transform.rotation);
        }

        public void lostLife() {
            Destroy(gameObject);
        }
    }
}
