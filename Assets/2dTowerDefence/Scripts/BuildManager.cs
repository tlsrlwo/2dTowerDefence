using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class BuildManager : MonoBehaviour
    {
        public static BuildManager main { get; set; }

        [Header("References")]
        //[SerializeField] private GameObject[] towerPrefabs;
        [SerializeField] private Tower[] towers;


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

        public Tower GetSelectedTower()
        {
            return towers[selectedTower];
        }

        public void SetSelectedTower(int _selectedTower)
        {
           selectedTower = _selectedTower; 

        }
    }
}
