using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Tank
{
    public class ItemTank : MonoBehaviour
    {
        public float rocketLevel = 1;
        public float boomLevel = 1;

        public static ItemTank instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
               // DontDestroyOnLoad(gameObject);
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
