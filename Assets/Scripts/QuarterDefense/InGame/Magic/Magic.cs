using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    public abstract class Magic : MonoBehaviour
    {
        [SerializeField] protected MagicData data = null;
        
        
        
        private float _damage = 1.0f;
        private float _speed = 5.0f;
        private float _damageRiseValue = 2.0f;
        
        
        protected virtual void Init()
        {
            _damage = data.Damage;
            _speed = data.Speed;
            _damageRiseValue = data.DamageRiseValue;
        }

        protected abstract void Move();
    }
}