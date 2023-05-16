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

        private List<Enemy> _enemyList = new List<Enemy>();

        private Coroutine _coroutine = null;

        [SerializeField]private Enemy preTarget = null;
        
        private void Start()
        {
            //StartCoroutine(Fire());
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
                yield return new WaitForSeconds(0.2f);
                
                if(preTarget) preTarget.SetSelect = false;
                
                var toList = _enemyList.OrderBy(
                    x => Vector3.Distance(transform.position, x.transform.position)).ToList();

                preTarget = toList[0];
                
                preTarget.SetSelect = true;

                preTarget.Damage(1);
            }
        }

        // private void Update()
        // {
        //     RaycastHit hit;
        //
        //     Debug.DrawRay(transform.position, Vector3.left * 20.0f, Color.red);
        //     
        //     if (Physics.Raycast(transform.position, transform.forward, out hit, 20.0f))
        //     {
        //         Debug.Log("????");
        //         
        //         hit.collider.GetComponent<Enemy>().SetSelect = true;
        //     }
        // }
        //
        //
        // private IEnumerator Fire()
        // {
        //     
        //     
        //     yield return new WaitForSeconds(3.0f);
        //     
        //     while (true)
        //     {
        //         yield return new WaitForSeconds(1.0f);
        //
        //         BaseBullet bullet = bulletController.FindUsableBullet();
        //
        //         if (!bullet) continue;
        //         
        //         bullet.Spawned();
        //     }
        // }
    }
}

