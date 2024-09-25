using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager main { get; set; }

        [Header("References")]
        [SerializeField] private GameObject[] towerPrefabs;

        private int selectedTower = 0;



        private void Awake()
        {
            if (main != null && main != this)
            {
                Destroy(gameObject);
            }
            else
            {
                main = this;
            }
        }

        public GameObject GetSelectedTower()
        {
            return towerPrefabs[selectedTower];
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
