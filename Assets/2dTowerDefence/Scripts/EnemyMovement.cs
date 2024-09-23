using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class EnemyMovement : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D rb;

        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 2f;

        private Transform target;
        private int pathIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            target = LevelManager.main.path[pathIndex];
        }

        // Update is called once per frame
        void Update()
        {
            // if enemy reach one targer, then change the target to the next target
            if(Vector2.Distance(target.position, transform.position) <= 0.1f)
            {
                pathIndex++;

                // enemy gameObject has reached the end of the path
                if(pathIndex == LevelManager.main.path.Length)
                {
                    EnemySpawner.onEnemyDestroy.Invoke();
                    Destroy(gameObject);
                    return;
                }
                else
                {
                    target = LevelManager.main.path[pathIndex];
                }
            }
        }

        private void FixedUpdate()
        {
            Vector2 direction = (target.position - transform.position).normalized;

            rb.velocity = direction * moveSpeed; 
        }
    }
}
