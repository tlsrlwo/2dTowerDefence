using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDF
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager main { get; set; }

        public Transform startPoint;
        public Transform[] path;

        // 돈을 모아서 터렛을 구매하기 위해 만듦
        public int currency;

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

        // Start is called before the first frame update
        void Start()
        {
            currency = 100;
        
        }

        public void IncreaseCurrency(int amount)
        {
            currency += amount;
        }   

        public bool SpendCurrency(int amount)
        {
            if (amount <= currency)
            {
                // buy item
                currency -= amount;
                return true;
            }
            else
            {
                Debug.Log("You do not have enough money");
                return false;
            }
        }

        
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
