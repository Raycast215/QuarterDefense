using System;
using QuarterDefense.Common;
using QuarterDefense.InGame.Interface;
using UnityEngine;

namespace QuarterDefense.InGame.Character.Enemy
{
    public class Enemy : MonoBehaviour, IHealth
    {
        public event Action<Enemy> OnDestroyed = delegate(Enemy enemy) {  };

        [SerializeField] private AnimationPlayer animationPlayer;
        [SerializeField] private Movement movement;
        [SerializeField] private SpriteRotate spriteRotate;
        
        private Transform[] _wayPoints;
        private int _targetIndex;
        
        private float _maxHealth;
        private float _curHealth;
        
        private Vector3 CurrentTransform => _wayPoints[_targetIndex].position;
        
        public bool Active => gameObject.activeInHierarchy;

        private void Start()
        {
            movement.OnDirectionChanged += spriteRotate.SetDirection;
            movement.OnMoveFinished += () => movement.SetTargetPos(CurrentTransform);
            movement.OnMoveFinished += () => Util.ClampCount(ref _targetIndex, 1, 0, _wayPoints.Length - 1);
        }

        public void Damage(float damage)
        {
            DecreaseHealth(damage);
        }

        public void SetEnemy(WayPoint wayPoint)
        {
            _wayPoints = wayPoint.GetWayPoints;
            
            animationPlayer.OnPlayAnimation(CharacterAniState.Walk);
            
            movement.SetPosition(_wayPoints[0].position);
            movement.SetTargetPos(CurrentTransform);
            
            SetMaxHealth(10);
            Init();
        }

        public void Init()
        {
            _curHealth = _maxHealth;
        }

        public void SetMaxHealth(float healthValue)
        {
            _maxHealth = healthValue;
        }

        public void DecreaseHealth(float delta)
        {
            _curHealth -= delta;
            
            CheckState();
        }
        
        private void CheckState()
        {
            if(_curHealth > 0.0f) return;
            
            OnDestroyed.Invoke(this);
            
            gameObject.SetActive(false);
        }
    }
}