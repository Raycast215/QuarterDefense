using System;
using System.Collections;
using QuarterDefense.InGame.Character.Enemy;
using QuarterDefense.InGame.Pool;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // 캐릭터의 공격 클래스.
    
    public class AttackSystem : MonoBehaviour
    {
        public event Action OnAttacked = delegate {  };
        public Func<bool> OnAttackStateChecked = () => false;

        private ProjectilePool _projectilePool;
        
        private float _delay;

        private void Start()
        {
            SetProjectile();
        }
        
        /// <summary>
        /// Attack 후 딜레이를 지정합니다.
        /// </summary>
        /// <param name="attackDelay"></param>
        public void Set(float attackDelay = 0.0f)
        {
            _delay = attackDelay;
        }

        /// <summary>
        /// 풀링된 오브젝트를 가져옵니다.
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="pos"></param>
        /// <param name="enemy"></param>
        public void GetProjectile(Character.CharacterRank rank, Vector3 pos, Enemy enemy)
        {
            _projectilePool.GetProjectile(rank, pos, enemy);
        }

        /// <summary>
        /// Attack 코루틴을 실행합니다.
        /// </summary>
        public void StartAttack()
        {
            StartCoroutine(OnAttack());
        }

        /// <summary>
        /// 풀링할 오브젝트를 저장합니다.
        /// </summary>
        private void SetProjectile()
        {
            GameObject.Find("ProjectilePool").TryGetComponent(out ProjectilePool projectilePool);

            _projectilePool = projectilePool;
        }
        
        /// <summary>
        /// Attack 이벤트를 실행합니다.
        /// </summary>
        /// <returns></returns>
        private IEnumerator OnAttack()
        {
            while (true)
            {
                // 공격 가능한 상태일 때까지 대기.
                yield return new WaitUntil(OnAttackStateChecked);

                OnAttacked.Invoke();
                
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}