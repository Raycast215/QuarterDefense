using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public enum PlayerType { Ice, Fire, Lightning }

    public enum PlayerRank { Normal, Rare, Unique, Legendary }
    
    public abstract class Player : MonoBehaviour
    {
        public Action OnPlayerInitialized = delegate {  };
        
        [SerializeField] private Animator animator = null;
        [SerializeField] protected Movement movement = null;
        [SerializeField] protected AttackSystem attackSystem = null;
        [SerializeField] protected EnemyChecker enemyChecker = null;
        [SerializeField] protected Magic.Magic magicPrefab = null;

        protected List<Magic.Magic> _magicList = new List<Magic.Magic>();

        private float _attackDelay = 1.0f; // SO 만든 후 데이터 불러오기.
        private float _moveSpeed = 5.0f; // SO 만든 후 데이터 불러오기.
        private float _range = 5.0f; // SO 만든 후 데이터 불러오기.
        
        private void Start()
        {
            Init();
        }
        
        private void Init()
        {
            InitData();
            OnPlayAnimation("Walk");
            
            OnPlayerInitialized += movement.Init;
            
            attackSystem.OnAttacked += () => OnPlayAnimation("Attack");
            attackSystem.OnAttacked += () => OnAttack(enemyChecker.TargetEnemy);
            attackSystem.OnAttackStateChecked = enemyChecker.CheckAttackState;
            attackSystem.Set(_attackDelay);
            
            enemyChecker.OnEnemyChanged += enemy => movement.SetDirection(enemy.transform.position);
            enemyChecker.SetRange(_range);
            
            movement.OnMoved += attackSystem.StartAttack;
            movement.OnMoved += () => OnPlayAnimation("Idle");
            
            OnPlayerInitialized.Invoke();
        }
        
        private void InitData()
        {
            // SO 데이터 초기화.
        }

        private void OnPlayAnimation(string clipName)
        {
            animator.Play($"Player_{clipName}", 0, 0.0f);
        }
        
        protected abstract void OnAttack(Enemy enemy);
    }
}

