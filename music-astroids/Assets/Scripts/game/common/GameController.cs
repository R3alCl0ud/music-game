using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace game.common {

    public class GameController : MonoBehaviour {

        // public fields
        public Text levelText;
        public Text scoreText;
        public GameObject lifeIcon;
        // public arrays
        public AudioClip[] music;

        // private fields
        private List<GameObject> lifeIcons = new List<GameObject>();
        private float stageStart = 0f;
        private int score = 0;
        private int level = 1;
        private int lives = 3;
        private int enemiesDestroyed = 0;
        private int enemiesInWave = 5;

        // public methods
        public void Start() {
            Physics2D.IgnoreLayerCollision(8, 8, true);
            stageStart = Time.time;
            for (int i = 0; i < 3; i++) {

            }
        }

        public void Update() {
            if (GameObject.FindGameObjectsWithTag("Asteroid").Length <= 0) {
                stageStart = Time.time;
                level++;
            }
        }

        public void addLife() {
            lives++;
        }

        public void removeLife() {
            lives--;
        }

        public void AddScore() {
            enemiesDestroyed++;
            score += (int) Mathf.Round(10f * (((Time.time - stageStart) + level) / enemiesDestroyed));
            scoreText.text = string.Format("Score: {0:X6}", score);
            if (score % 1500 == 0 && score != 0) {
                addLife();
            }
        }

        // private methods
        private void calculateEnemies() {
            enemiesInWave = Mathf.RoundToInt(enemiesInWave * Mathf.Max(1, Mathf.Log(level)));
        }

        private IEnumerator StartRound() {
            yield return new WaitForSecondsRealtime(0.25f);
            calculateEnemies();

        }
    }
}
