using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuarterDefense.InGame.Bullet;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private BulletController bulletController = null;

        [SerializeField] private Animator animator = null;
        
        private List<Enemy> _enemyList = new List<Enemy>();

        private Coroutine _coroutine = null;

        [SerializeField]private Enemy preTarget = null;
        
        private void Start()
        {
            // StartCoroutine(Attack());
        }


        private IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.0f);
                
                animator.Play("Player_Attack", 0, 0.0f);
            }
        }
        
        
        
        
        public void SetEnemyList(List<Enemy> enemyList)
        {
            _enemyList = enemyList;

            if(_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(OnAttack());
        }

        private IEnumerator OnAttack()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                
                var toList = _enemyList.OrderBy(
                    x => Vector3.Distance(transform.position, x.transform.position)).ToList();

                preTarget = toList[0];
                
                preTarget.Damage(1);
            }
        }
    }
}

