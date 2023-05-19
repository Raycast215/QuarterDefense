using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class EnemyManager : MonoBehaviour
    {
        private const float SpawnDelay = 1.0f;
        private const float WaitPos = 999.0f;
        
        [SerializeField] private int maxEnemyCount = 200;
        [SerializeField] private WayPoint wayPoint = null;

        private List<Enemy> _enemyList = null;
        
        public void Create(WaveData toWaveData)
        {
            _enemyList = new List<Enemy>();
            
            for (int i = 0; i < toWaveData.CreateCount; i++)
            {
                Enemy enemy = Instantiate(GetPrefabs(toWaveData.EnemyName), transform);
                enemy.OnDestroyed += RemoveEnemy;
                enemy.SetPos(WaitPos, WaitPos);
                
                _enemyList.Add(enemy);
            }

            StartCoroutine(OnSpawnDelay());
        }

        private void Spawn()
        {
            
        }

        private IEnumerator OnSpawnDelay()
        {
            foreach (var enemy in _enemyList)
            {
                yield return new WaitForSeconds(SpawnDelay);

                enemy.SetEnemy(wayPoint);
            }
        }

        private Enemy GetPrefabs(string prefabName)
        {
            return Resources.Load<Enemy>($"Enemy/{prefabName}");
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemyList.Remove(enemy);
            
            Debug.Log($"{enemy.name} Dead...");
        }
    }
}