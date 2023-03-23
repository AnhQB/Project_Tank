using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets.Script.Tank
{
    public class ItemTank : MonoBehaviour
    {
        public float rocketLevel = 1;
        public float dameRocket = 20f;
        public float boomLevel = 1;
        public float dameBoom = 20f;
       

        public static ItemTank instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static ItemTank GetInstance()
        {
            return instance;
        }

        
    }
}
