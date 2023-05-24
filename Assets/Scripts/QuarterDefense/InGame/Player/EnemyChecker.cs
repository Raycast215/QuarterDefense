using System;
using System.Linq;
using QuarterDefense.Common;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class EnemyChecker : MonoBehaviour
    {
        private const float BaseRange = 10.0f;
     
        public event Action<Enemy> OnEnemyChanged = delegate(Enemy enemy) {  }; 

        public Enemy TargetEnemy { get; private set; }
        
        private EnemySystem _enemySystem = null;
        private float _range = 0.0f;

        public void Set(float range = BaseRange)
        {
            GameObject.Find("EnemySystem").TryGetComponent(out EnemySystem enySystem);

            _enemySystem = enySystem;
            
            _range = range;
        }

        /// <summary>
        /// 공격 가능한 Enemy가 있는지 반환합니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckAttackState()
        {
            FindNearEnemy(transform.position);
            
            return _enemySystem.GetEnemyCount() > 0 && TargetEnemy;
        }
        
        /// <summary>
        /// 가장 가까운 거리의 Enemy를 찾습니다.
        /// </summary>
        /// <returns></returns>
        private void FindNearEnemy(Vector3 curPos)
        {
            TargetEnemy = _enemySystem.EnemyList
                .OrderByDescending(x => Util.GetDistance(curPos, x.transform.position) < _range)
                .FirstOrDefault();
            
            OnEnemyChanged.Invoke(TargetEnemy);
        }
    }
}