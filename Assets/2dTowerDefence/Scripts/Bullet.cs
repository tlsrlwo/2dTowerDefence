using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class Bullet : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Rigidbody2D rb;

        [Header("Attributes")]
        [SerializeField] private float bulletSpeed = 5f;
        [SerializeField] private int bulletDmg = 1; 

         private Transform target;
        

        public void SetTarget(Transform _target)
        {
            //터렛의 target 값을 받아옴
            target = _target;

        }

        private void FixedUpdate()
        {
            if (!target) return;  // 타겟의 값이 없으면 식 반환

            Vector2 direction = (target.position - transform.position).normalized;
            
            rb.velocity = direction * bulletSpeed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(bulletDmg);
            Destroy(gameObject);
        }

    }
}
