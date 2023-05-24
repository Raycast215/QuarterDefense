using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class EnemySystem : MonoBehaviour
    {
        private const float SpawnDelay = 1.0f;
        private const float WaitPos = 999.0f;
        
        public event Action<int> OnEnemyCountChecked = delegate(int i) {  };
        
        [SerializeField] private WayPoint wayPoint = null;

        public List<Enemy> EnemyList { get; private set; } = null;

        public void Create(WaveData toWaveData)
        {
            EnemyList = new List<Enemy>();
            
            for (int i = 0; i < toWaveData.CreateCount; i++)
            {
                Enemy enemy = Instantiate(GetPrefabs(toWaveData.EnemyName), transform);
                enemy.OnDestroyed += RemoveEnemy;
                enemy.SetPos(WaitPos, WaitPos);
                
                EnemyList.Add(enemy);
            }

            StartCoroutine(OnSpawnDelay());
        }

        public int GetEnemyCount()
        {
            if (EnemyList == null) return 0;
            
            int count = EnemyList.Count(x => x.Active);

            return count;
        }
        
        private IEnumerator OnSpawnDelay()
        {
            foreach (var enemy in EnemyList)
            {
                yield return new WaitForSeconds(SpawnDelay / Time.timeScale);

                enemy.SetEnemy(wayPoint);
                
                OnEnemyCountChecked.Invoke(GetCurrentEnemyCount());
            }
        }

        private Enemy GetPrefabs(string prefabName)
        {
            return Resources.Load<Enemy>($"Enemy/{prefabName}");
        }

        private void RemoveEnemy(Enemy enemy)
        {
            Debug.Log($"{enemy.name} Dead...");
        }

        /// <summary>
        /// 현재 생존해있는 Enemy의 수를 반환하는 함수입니다.
        /// </summary>
        /// <returns></returns>
        private int GetCurrentEnemyCount()
        {
            Enemy[] enemies = GetComponentsInChildren<Enemy>();
            
            return enemies.Select(x => x.gameObject.activeInHierarchy).Count();
        }
    }
}