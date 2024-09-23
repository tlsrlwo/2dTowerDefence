using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GameObject[] enemyPrefabs;

        [Header("Attributes")]
        [SerializeField] private int baseEnemies = 8;
        [SerializeField] private float enemiesPerSecond = 0.5f;
        [SerializeField] private float timeBetweenWaves = 5f;
        [SerializeField] private float difficultyScalingFactor = 0.75f;

        private int currentWave = 1;
        private float timeSinceLastSpawn;
        private int enemiesAlive;
        private int enemiesLeftToSpawn;
        private bool isSpawning = false;

        private void Start()
        {
            StartWave();
        }

        void Update()
        {
            if (!isSpawning)
                return;

            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= 1f / enemiesPerSecond && enemiesLeftToSpawn > 0)
            {                
                SpawnEnemy();
                enemiesLeftToSpawn--;
                enemiesAlive++; 
                timeSinceLastSpawn = 0f;
            }
        }

        void StartWave()
        {
            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
        }

        private int EnemiesPerWave()
        {
            //RountToInt �� �ݿø�, pow �� ����
            return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
        }

        private void SpawnEnemy()
        {
            Debug.Log("spawn enemy");
            GameObject prefabToSpawn = enemyPrefabs[0];
            Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity); 
            //startPoint �� ���� Transform ���� Vector3 �� ��ȯ��Ű�� ���ϱ� ������ �ڿ� .position �� ���� (Vector3 Transform.position)
        }
    }
}
