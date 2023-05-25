using System;
using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    // Scripted by Raycast
    // 2023. 05. 24
    // Player의 공격 클래스.
    
    public class AttackSystem : MonoBehaviour
    {
        public event Action OnAttacked = delegate {  };
        public Func<bool> OnAttackStateChecked = null;

        private float _delay;

        /// <summary>
        /// Attack 후 딜레이를 지정합니다.
        /// </summary>
        /// <param name="attackDelay"></param>
        public void Set(float attackDelay = 0.0f)
        {
            _delay = attackDelay;
        }

        /// <summary>
        /// Attack 코루틴을 실행합니다.
        /// </summary>
        public void StartAttack()
        {
            StartCoroutine(OnAttack());
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