using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuarterDefense.InGame.Character.Enemy;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class EnemySystem : MonoBehaviour
    {
        private const float SpawnDelay = 0.5f;

        public event Action OnEnemyCreated = delegate {  };
        public event Action OnEnemyDestroyed = delegate {  };
        //public event Action<int> OnEnemyCountChecked = delegate {  };

        [SerializeField] private WayPoint wayPoint = null;

        public List<Enemy> EnemyList { get; private set; } = new List<Enemy>();

        public void Create(WaveData toWaveData)
        {
            StartCoroutine(OnSpawnDelay(toWaveData));
        }

        public int GetEnemyCount()
        {
            if (EnemyList == null) return 0;
            
            int count = EnemyList.Count(x => x.Active);

            return count;
        }
        
        private IEnumerator OnSpawnDelay(WaveData toWaveData)
        {
            for (int i = 0; i < toWaveData.CreateCount; i++)
            {
                yield return new WaitForSeconds(SpawnDelay);
                
                Enemy enemy = Instantiate(GetPrefabs(toWaveData.EnemyID), transform);
                
                enemy.OnDestroyed += RemoveEnemy;
                // enemy.OnDestroyed += _ => OnEnemyCountChecked.Invoke(GetEnemyCount());
                
                enemy.SetEnemy(wayPoint);
                
                EnemyList.Add(enemy);
                
                OnEnemyCreated.Invoke();
                //OnEnemyCountChecked.Invoke(GetEnemyCount());
            }
        }

        private Enemy GetPrefabs(string prefabName)
        {
            return Resources.Load<Enemy>($"InGame/Enemy/{prefabName}");
        }

        private void RemoveEnemy(Enemy enemy)
        {
            OnEnemyDestroyed.Invoke();
        }
    }
}