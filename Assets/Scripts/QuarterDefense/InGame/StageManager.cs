using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.UI;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private WaveViewer waveViewer = null;
        [SerializeField] private EnemyManager enemyManager = null;
        
        
        private bool _isStart = false;
        
        
        
      
        
        private float _time = 0.0f;
        private float _waveTime = 30.0f;
        
        // 게임이 시작되면 30초 동안 카운트 시작.
        // 1초마다 적 생성.
        // 0초가 되면 웨이브 증가 및 반복

     
        
        private void Start()
        {
            enemyManager.CreateEnemy(0);
            
            waveViewer.Set(1);
            StartCoroutine(OnCountdown());
        }

        private IEnumerator OnCountdown()
        {
            while (true)
            {
                _time += Time.deltaTime;

                if (_time >= _waveTime)
                {
                    _time = 0.0f;
                    waveViewer.Set(1);
                }
                
                yield return null;
            }
        }
    }
}