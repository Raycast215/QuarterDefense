using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using QuarterDefense.InGame.Bullet;
using QuarterDefense.InGame.Interface;
using UnityEngine;

namespace QuarterDefense.InGame.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Movement movement = null;
        
        private Enemy _target = null;
        
        private void Start()
        {
            StartCoroutine(Attack());
        }
       

        private IEnumerator Attack()
        {
            while (true)
            {
                yield return new WaitForSeconds(2.0f);
                
                _target = SearchNearEnemy();
                
                if (!_target) continue;
                
                //spriteRenderer.flipX = CheckDirection(_target);
                
                //_target.Damage(1);
                
                // animator.Play("Player_Attack", 0, 0.0f);
                
                
            }
        }


        private Enemy SearchNearEnemy()
        {
            Collider[] colls = Physics.OverlapSphere(transform.position, 10.0f);
            
            _target = colls.OrderByDescending(x => Vector3.Distance(transform.position, x.transform.position) < 1.0f)
                .FirstOrDefault()
                ?.GetComponent<Enemy>();
            
            return _target;
        }
    }
}

