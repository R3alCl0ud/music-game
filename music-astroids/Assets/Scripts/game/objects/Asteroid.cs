using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace game.objects {
    public class Asteroid : MovingObject {

        public GameObject asteroid;
        public AudioClip audioKick;
        public AudioSource audioSource;

        public int level = 0;

        new void Start() {
            ((MovingObject) this).Start();
            rb.AddForce(transform.up * 20f);
            if (rb.mass < 0.055f) {
                Destroy(gameObject);
            }
            audioSource = GetComponent<AudioSource>();
            //if (audioSource != null) {
            //    audioSource.enabled = true;
            //}
            //if (audioKick != null) {
            //    audioKick.LoadAudioData();
            //}
        }

        public void setMass(int mass) {
            rb.mass = mass;
        }

        public void setLevel(int level) {
            this.level = level;
        }

        new void Update() {
            ((MovingObject) this).Update();
        }

        public void Exploded() {
            if (rb.mass < 0.05f) {
                DestroyImmediate(gameObject);
            }
        }

        void OnDestroy() {
            GameObject.FindGameObjectWithTag("GameController").SendMessage("AddScore");
        }

        private float calculatePitch() {
            Debug.Log(1f + (2f / (0.554177f - rb.mass)));
            //return Mathf.Max(1f, Mathf.Min(3f, 0.554177f / Mathf.Min(0.554177f, (0.554177f - rb.mass))));
            return Mathf.Max(1f, Mathf.Min(3f, 1f + (2f * (0.554177f - rb.mass))));
        }

        public void PlaySound() {
            if (audioSource != null && audioKick != null && audioSource.isActiveAndEnabled && !audioSource.isPlaying) {
                Debug.Log("Attempting to play audio");
                Debug.Log(audioSource.volume);
                audioSource.clip = audioKick;
                audioSource.pitch = calculatePitch();
                Debug.Log(audioSource.pitch);
                audioSource.Play();
            }
        }

        void OnCollisionEnter2D(Collision2D coll) {
            if (coll.gameObject.tag == "Bullet") {
                if (rb.mass > 0.05f) {
                    int na = Mathf.RoundToInt(Random.Range(2, 4));
                    for (int i = 0; i < na; i++) {
                        GameObject g = Instantiate(asteroid, transform.position, transform.rotation);
                        g.transform.Rotate(Vector3.forward, (360 / na) * i);
                        g.transform.Translate(0, 0.1f, 0);
                        g.transform.localScale -= transform.localScale / (na);
                        g.GetComponent<Rigidbody2D>().mass /= na;
                    }
                }
                Destroy(coll.gameObject);
                PlaySound();
                rb.isKinematic = false;
                GetComponent<SpriteRenderer>().enabled = false;
                Destroy(gameObject, 0.2f);
            }
        }
    }
}
