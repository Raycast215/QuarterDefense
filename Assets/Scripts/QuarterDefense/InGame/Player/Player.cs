using System;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public enum PlayerType { Ice, Fire, Lightning }

    public enum PlayerRank { Normal, Rare, Unique, Legendary }
    
    public abstract class Player : MonoBehaviour
    {
        public Action OnPlayerInitialized = delegate {  };
        
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private AnimationPlayer aniPlayer;
        [SerializeField] protected Movement movement;
        [SerializeField] protected AttackSystem attackSystem;
        [SerializeField] protected EnemyChecker enemyChecker;
        [SerializeField] protected Magic.Magic magicPrefab;

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

            OnPlayerInitialized += movement.Init;
            
            attackSystem.Set(_attackDelay);
            attackSystem.OnAttacked += () => aniPlayer.OnPlayAnimation(CharacterAniState.Attack);
            attackSystem.OnAttacked += () => OnAttack(enemyChecker.TargetEnemy);
            attackSystem.OnAttackStateChecked = enemyChecker.CheckAttackState;
            
            enemyChecker.SetRange(_range);
            enemyChecker.OnEnemyChanged += enemy => movement.SetDirection(enemy.transform.position);
            
            movement.OnMoveFinished += attackSystem.StartAttack;
            movement.OnMoveFinished += () => aniPlayer.OnPlayAnimation(CharacterAniState.Idle);
            
            OnPlayerInitialized.Invoke();
        }
        
        private void InitData()
        {
            // SO 데이터 초기화.
        }

        protected abstract void OnAttack(Enemy enemy);
    }
}