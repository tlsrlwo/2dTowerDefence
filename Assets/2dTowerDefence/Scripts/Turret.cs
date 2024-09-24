using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace TDF
{
    public class Turret : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform turretRotationPoint;
        [SerializeField] private LayerMask enemyMask; 

        [Header("Attributes")]
        [SerializeField] private float targetingRange = 5f;
        [SerializeField] private float rotationSpeed = 5f;

        private Transform target;

        private void Update()
        {
            if (target == null)
            {
                FindTarget();
                return;
            }

            RotateTowardsTarget();

            if (!CheckTargetIsInRange())
            {
                target= null; 
            }
        }

        private bool CheckTargetIsInRange()
        {
            return Vector2.Distance(target.position, transform.position) <= targetingRange;
        }

        private void RotateTowardsTarget()
        {
            float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        private void FindTarget()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);
            //CircleCastAll(Vector2 origin, float radius, Vecotr2 direction)

            if(hits.Length > 0 )
            {
                target = hits[0].transform;         // get the first transform of the enemy this has hit
            }
        }

        private void OnDrawGizmosSelected()
        {
            Handles.color = Color.cyan;
            //DrawWireDisc(Vector3 center, Vector3 normal, float radius)
            Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);

        }
    }
}
