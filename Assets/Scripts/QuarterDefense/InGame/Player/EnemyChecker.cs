using System;
using System.Linq;
using QuarterDefense.Common;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Enemy를 탐색 및 체크하는 클래스.
    
    public class EnemyChecker : MonoBehaviour
    {
        public event Action<Enemy> OnEnemyChanged = delegate {  }; 

        public Enemy TargetEnemy { get; private set; }
        
        private EnemySystem _enemySystem;
        private float _range;

        private void Start()
        {
            SetEnemySystem();
        }

        /// <summary>
        /// Enemy를 탐색할 범위를 지정합니다.
        /// </summary>
        /// <param name="range"></param>
        public void SetRange(float range)
        {
            _range = range;
        }

        /// <summary>
        /// 공격 가능한 Enemy가 있는지 반환합니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckAttackState()
        {
            FindNearEnemy(transform.localPosition);

            return _enemySystem.GetEnemyCount() > 0 && TargetEnemy;
        }
        
        /// <summary>
        /// EnemySystem을 찾아 저장합니다.
        /// </summary>
        private void SetEnemySystem()
        {
            GameObject.Find("EnemySystem").TryGetComponent(out EnemySystem enemySystem);

            _enemySystem = enemySystem;
        }
        
        /// <summary>
        /// 가장 가까운 거리의 Enemy를 찾습니다.
        /// </summary>
        /// <returns></returns>
        private void FindNearEnemy(Vector3 curPos)
        {
            TargetEnemy = _enemySystem.EnemyList
                .Where(x => Util.GetDistance(curPos, x.transform.localPosition) <= _range)
                .FirstOrDefault(x => x.gameObject.activeInHierarchy);
            
            if (TargetEnemy) OnEnemyChanged.Invoke(TargetEnemy);
        }
    }
}