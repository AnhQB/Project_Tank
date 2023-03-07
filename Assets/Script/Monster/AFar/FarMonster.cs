using Assets.Script.Monster.Close;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Assets.Script.Monster.AFar
{
    public class FarMonster : MonoBehaviour, IMonster
    {
        public GameObject prefabExplosion;
        private const float distanceToAttack = 10f;

        private static FarMonster instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        public static FarMonster GetInstance()
        {
            return instance;
        }
        public void Attack(float dame, GameObject monster)
        {
            
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
