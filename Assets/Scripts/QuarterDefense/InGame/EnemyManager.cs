using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class EnemyManager : MonoBehaviour
    {
        private const float CreateTime = 1.0f;

        [SerializeField] private int maxEnemyCount = 200;
        [SerializeField] private WayPoint wayPoint = null;
        
        private string _enemyName = "Enemy";

        private List<Enemy> _enemyList = new List<Enemy>();

        private Coroutine _createRoutine = null;
        
        public void CreateEnemy(int wave)
        {
            // wave에 따라 csv 에서 해당하는 에너미 생성하기

            if(_createRoutine != null) StopCoroutine(_createRoutine);
            _createRoutine = StartCoroutine(OnCreate(20));
        }

        private IEnumerator OnCreate(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return new WaitForSeconds(CreateTime);
                
                Enemy instance = Instantiate(GetPrefabs(_enemyName), transform);
                
                instance.SetEnemy(wayPoint);
            }
        }
        
        private Enemy GetPrefabs(string prefabName)
        {
            return Resources.Load<Enemy>($"Enemy/{prefabName}");
        }
    }
}