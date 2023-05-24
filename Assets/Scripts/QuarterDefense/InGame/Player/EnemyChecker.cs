using System;
using System.Linq;
using QuarterDefense.Common;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Enemy를 체크하는 클래스.
    
    public class EnemyChecker : MonoBehaviour
    {
        public event Action<Enemy> OnEnemyChanged = delegate(Enemy enemy) {  }; 

        public Enemy TargetEnemy { get; private set; }
        
        private EnemySystem _enemySystem = null;
        private float _range = 0.0f;

        public void Set(float range)
        {
            TargetEnemy = null;
            
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
            FindNearEnemy(transform.localPosition);

            return _enemySystem.GetEnemyCount() > 0 && TargetEnemy;
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