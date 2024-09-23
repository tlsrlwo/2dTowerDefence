using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

        [Header("Events")]
        public static UnityEvent onEnemyDestroy = new UnityEvent();

        private int currentWave = 1;
        private float timeSinceLastSpawn;
        private int enemiesAlive;
        private int enemiesLeftToSpawn;
        private bool isSpawning = false;


        private void Awake()
        {
            onEnemyDestroy.AddListener(EnemyDestroyed);
        }

        private void Start()
        {
            StartCoroutine(StartWave());
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

            if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
            {
                EndWave();
            }
        }

        void EnemyDestroyed()
        {
            enemiesAlive--;
        }

        private IEnumerator StartWave()
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            isSpawning = true;
            enemiesLeftToSpawn = EnemiesPerWave();
        }

        void EndWave()
        {
            isSpawning = false;
            timeSinceLastSpawn = 0f;
            currentWave++;

            StartCoroutine(StartWave());
        }

        private int EnemiesPerWave()
        {
            //RountToInt 은 반올림, pow 는 제곱
            return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScalingFactor));
        }

        private void SpawnEnemy()
        {
            Debug.Log("spawn enemy");
            GameObject prefabToSpawn = enemyPrefabs[0];
            Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
            //startPoint 만 쓰면 Transform 값을 Vector3 로 변환시키지 못하기 때문에 뒤에 .position 을 써줌 (Vector3 Transform.position)
        }
    }
}
