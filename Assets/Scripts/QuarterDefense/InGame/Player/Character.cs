using System;
using QuarterDefense.InGame.Character;
using QuarterDefense.InGame.Character.Enemy;
using QuarterDefense.InGame.Magic;
using QuarterDefense.InGame.Pool;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace QuarterDefense.InGame.Player
{
    public class Character : MonoBehaviour
    {
        public enum CharacterRank { Normal, Rare, Unique, Legendary }
        
        public event Action <Character> OnDied = delegate {  };

        [SerializeField] private Movement movement;
        [SerializeField] private AnimationPlayer aniPlayer;
        [SerializeField] private SpriteRotate spriteRotate;
        [SerializeField] private SpriteLibrary spriteLibrary;
        [SerializeField] private AttackSystem attackSystem;
        [SerializeField] private EnemyChecker enemyChecker;

        [SerializeField] private GameObject flyObject;
        [SerializeField] private GameObject auraObject;
        
        private float _attackDelay = 1.0f; // SO 만든 후 데이터 불러오기.
        private float _range = 5.0f; // SO 만든 후 데이터 불러오기.
        
        public CharacterRank Rank { get; set; }
        public SpriteLibraryAsset CharacterSprite { set => spriteLibrary.spriteLibraryAsset = value; }
        
        private void Start()
        {
            attackSystem.Set(_attackDelay);
            attackSystem.OnAttacked += () => aniPlayer.OnPlayAnimation(CharacterAniState.Attack);
            attackSystem.OnAttacked += () => Attack(enemyChecker.TargetEnemy);
            attackSystem.OnAttackStateChecked = enemyChecker.CheckAttackState;
            
            enemyChecker.SetRange(_range);
            enemyChecker.OnEnemyChanged += enemy => spriteRotate.SetDirection(enemy.transform.position);
            
            movement.OnDirectionChanged += spriteRotate.SetDirection;
            movement.OnMoveFinished += attackSystem.StartAttack;
            movement.OnMoveFinished += () => aniPlayer.OnPlayAnimation(CharacterAniState.Idle);
        }

        private void OnEnable()
        {
            SetEffect(flyObject, Rank is CharacterRank.Unique or CharacterRank.Legendary);
            SetEffect(auraObject, Rank is CharacterRank.Legendary);
        }

        private void OnDisable()
        {
            SetEffect(flyObject, false);
            SetEffect(auraObject, false);
            
            OnDied.Invoke(this);
        }

        private void SetEffect(GameObject effect, bool isActive)
        {
            effect.SetActive(isActive);
        }
        
        private void Attack(Enemy enemy)
        {
           // projectilePool.GetProjectile(Rank, transform.position, enemy);
        }
    }
}