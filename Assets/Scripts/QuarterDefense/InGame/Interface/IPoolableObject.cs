using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Interface
{
    public interface IPoolableObject
    {
        public void Spawned();
        public void Despawned();
    }
}