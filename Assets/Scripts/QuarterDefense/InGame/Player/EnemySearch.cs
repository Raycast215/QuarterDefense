using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class EnemySearch : MonoBehaviour
    {
        [SerializeField] private EnemySystem _enemySystem = null;
        
        private void Start()
        {
            GameObject.Find("EnemySystem").TryGetComponent(out EnemySystem enySystem);

            _enemySystem = enySystem;
        }
    }
}


