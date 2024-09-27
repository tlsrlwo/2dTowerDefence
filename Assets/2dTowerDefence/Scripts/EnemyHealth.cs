using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class EnemyHealth : MonoBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private int hitPoints = 2;        
        [SerializeField] private int currencyWorth = 50; // enemy 죽일때마다 얻는 금액

        private bool isDestroyed = false;


        public void TakeDamage(int dmg)
        {
            hitPoints -= dmg;

            if(hitPoints <= 0 && !isDestroyed)
            {
                EnemySpawner.onEnemyDestroy.Invoke();
                LevelManager.main.IncreaseCurrency(currencyWorth);
                isDestroyed = true;
                Destroy(gameObject);
            }
        }


    }
}
