using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public int enemyCount;
    public int waveCount = 1;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start() {
        SpawnEnemyWave(waveCount);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update() {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) {
            waveCount++;
            SpawnEnemyWave(waveCount);
            SpawnPowerup();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);   
        }
    }

    private void SpawnPowerup() {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}