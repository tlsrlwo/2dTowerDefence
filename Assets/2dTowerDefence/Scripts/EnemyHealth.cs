using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private int hitPoints = 2;

        private bool isDestroyed = false;

        public void TakeDamage(int dmg)
        {
            hitPoints -= dmg;

            if(hitPoints <= 0 && !isDestroyed)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                isDestroyed = true;
                Destroy(gameObject);
            }
        }


    }
}
