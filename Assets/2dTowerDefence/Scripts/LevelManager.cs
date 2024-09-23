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
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
