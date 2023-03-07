using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.Monster
{
    public interface IMonster
    {
        public void Move(float speed, GameObject monster);

        public void Attack(float dame, GameObject monster);

        public void Destroy(GameObject monster);
    }
}
