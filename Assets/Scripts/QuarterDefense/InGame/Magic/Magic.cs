using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    public abstract class Magic : MonoBehaviour
    {
        [SerializeField] protected MagicData data;
        
        private float _damage;
        private float _speed;
        private float _damageRiseValue;
        
        
        protected virtual void Init()
        {
            _damage = data.Damage;
            _speed = data.Speed;
            _damageRiseValue = data.DamageRiseValue;
        }

        protected abstract void Move();
    }
}