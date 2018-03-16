using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {


    public List<Wave> waves = new List<Wave>();
    public static int enemiesAlive = 0;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.0f;
    private float countDown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (enemiesAlive > 0)
            return;

        if (countDown <= 0) {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }
        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown, 0, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countDown);// Mathf.Round(countDown).ToString();
	}

    IEnumerator SpawnWave() {

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.armySize; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f/wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Count) {
            Debug.Log("level complete. No more enemies");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject _enemy) {
        Instantiate(_enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}
