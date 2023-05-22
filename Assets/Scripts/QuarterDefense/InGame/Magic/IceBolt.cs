using System;
using UnityEngine;

namespace QuarterDefense.InGame.Magic
{
    public class IceBolt : Magic
    {
        [SerializeField]private Enemy _targetEnemy;

        private void Start()
        {
            Init();
        }

        private void FixedUpdate()
        {
            Move();
            RotateTowardsTarget(_targetEnemy.transform);
        }

        public void SetEnemy(Enemy targetEnemy)
        {
            _targetEnemy = targetEnemy;
        }
        
        protected override void Move()
        {
            if(CheckTarget()) return;
            
            transform.position = Vector3.MoveTowards(transform.position, _targetEnemy.transform.position, data.Speed * Time.deltaTime);
            
           
        }
        
        private void RotateTowardsTarget(Transform target)
        {
            if(CheckTarget()) return;
            
            float angle = Mathf.Atan2(GetDistanceToTarget(target).y, GetDistanceToTarget(target).x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void Destroy()
        {
            if(Vector3.Distance(_targetEnemy.transform.position, transform.position) <= 0.0f) gameObject.SetActive(false);
        }
        
        private Vector3 GetDistanceToTarget(Transform target)
        {
            return target.position - transform.position;
        }

        private bool CheckTarget()
        {
            return !_targetEnemy.gameObject.activeInHierarchy || _targetEnemy == null;
        }
    }
}