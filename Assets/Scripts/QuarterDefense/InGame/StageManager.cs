using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace QuarterDefense.InGame
{
    public class StageManager : MonoBehaviour
    {
        private const string CsvPath = "CSV/WaveDataSheet";
        
        [SerializeField] private WaveViewer waveViewer = null;
        [SerializeField] private WaveTimeViewer waveTimeViewer = null;
        
        
        [SerializeField] private EnemyManager enemyManager = null;

        [SerializeField] private bool _isStart = false;

        private int _curWave = 0;
        private float _waveTime = 0.0f;

        private Coroutine _waveTimeRoutine = null;

        private List<WaveData> _waveDataList = null;

        private void Start()
        {
            void OnComplete()
            {
                _isStart = true;
                StartCoroutine(StartStage());
            }
            
            LoadWaveData(OnComplete);
        }

        private void LoadWaveData(Action onComplete)
        {
            var toList = CSVReader.Read(CsvPath);

            // Wave Data 리스트 예외.
            if (toList == null || toList.Count <= 0)
            {
                Debug.LogError($"CSV Load Failed... Path : {CsvPath}");
                return;
            }
            
            _waveDataList = new List<WaveData>();
            
            foreach (var data in toList)
            {
                // Wave Data 리스트에 Data 저장.
                _waveDataList.Add(new WaveData
                {
                    Wave = Int32.Parse($"{data["Wave"]}"),
                    WaveTime = float.Parse($"{data["Time"]}"),
                    EnemyName = $"{data["EnemyName"]}",
                    CreateCount = int.Parse($"{data["CreateCount"]}")
                });
            }
            
            onComplete.Invoke();
        }

        private IEnumerator StartStage()
        {
            while (true)
            {
                // 시작 플래스 체크까지 대기.
                yield return new WaitUntil(() => _isStart);
                
                _curWave =  _curWave >= _waveDataList.Count ? _waveDataList.Count - 1 :_waveDataList[_curWave].Wave;
                _waveTime = _waveDataList[_curWave - 1].WaveTime;
                waveViewer.Set(1);
                // Countdown();
                
                enemyManager.Create(_waveDataList[_curWave - 1]);
                
                _isStart = false;
            }
        }

        private void Countdown()
        {
            if(_waveTimeRoutine != null) StopCoroutine(_waveTimeRoutine);
            _waveTimeRoutine = StartCoroutine(OnCountdown(_waveTime));
        }
        
        private IEnumerator OnCountdown(float targetTime)
        {
            yield return new WaitForSeconds(targetTime);

            _isStart = true;
        } 
    }
    
    public class WaveData
    {
        public int Wave;
        public float WaveTime;
        public string EnemyName;
        public int CreateCount;
    }
}