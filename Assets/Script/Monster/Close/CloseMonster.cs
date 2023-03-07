using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Monster.Close
{
    public class CloseMonster : MonoBehaviour, IMonster
    {
        public GameObject prefabExplosion;
        private static CloseMonster instance;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static CloseMonster GetInstance()
        {
            return instance;
        }
        public void Attack(float dame, GameObject monster)
        {
            throw new NotImplementedException();
        }

        public void Move(float speed, GameObject monster)
        {
            GameObject targetPickup = GameObject.FindWithTag("TankBody");
            monster.transform.position = Vector3.MoveTowards(monster.transform.position, targetPickup.transform.position, speed);
        }

        public void Destroy(GameObject monster)
        {
            Instantiate<GameObject>(prefabExplosion, monster.transform.position, Quaternion.identity);
        }
    }
}
