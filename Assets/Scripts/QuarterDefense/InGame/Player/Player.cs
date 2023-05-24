using System;
using System.Collections;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public abstract class Player : MonoBehaviour
    {
        [SerializeField] private Animator animator = null;
        [SerializeField] protected Movement movement = null;
        [SerializeField] protected AttackSystem attackSystem = null;
        [SerializeField] protected EnemyChecker enemyChecker = null;
        [SerializeField] protected Transform magicLayer = null;
        [SerializeField] protected Magic.Magic magicPrefab = null;

        private float _attackDelay = 1.0f; // SO 만든 후 데이터 불러오기.
        private float _moveSpeed = 5.0f; // SO 만든 후 데이터 불러오기.
        private float _range = 10.0f; // SO 만든 후 데이터 불러오기.

        private bool _isActive = true;
        
        protected virtual IEnumerator Start()
        {
            yield return new WaitForSeconds(3.0f); // 게임 준비 플래그로 바꾸기
            yield return new WaitUntil(() => _isActive); // 게임 준비 플래그로 바꾸기
            
            Init();
        }

        private void Init()
        {
            InitData();
            
            attackSystem.OnAttacked += OnPlayAttackSystemAni;
            attackSystem.OnAttacked += () => OnAttack(enemyChecker.TargetEnemy);
            attackSystem.OnAttackStateChecked = enemyChecker.CheckAttackState;
            attackSystem.Set(_attackDelay);
            
            enemyChecker.OnEnemyChanged += enemy => movement.SetDirection(enemy.transform.position);
            enemyChecker.Set(_range);
            
            movement.OnMoved += attackSystem.StartAttack;
            movement.Set(_moveSpeed);
            movement.Move();
        }

        private void InitData()
        {
            // SO 데이터 초기화.
        }
        
        protected abstract void OnAttack(Enemy enemy);

        private void OnPlayAttackSystemAni()
        {
            animator.Play("Player_Attack", 0, 0.0f);
        }
    }
}

