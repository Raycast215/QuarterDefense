using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.UI;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class WaveManager : MonoBehaviour
    {
        private const string CsvPath = "CSV/WaveDataSheet";
        
        [SerializeField] private WaveViewer waveViewer = null;
        [SerializeField] private WaveTimeViewer waveTimeViewer = null;
        [SerializeField] private EnemyCountViewer enemyCountViewer = null;
        [SerializeField] private EnemyManager enemyManager = null;

        [SerializeField] private int maxEnemyCount = 256;
        
        private bool _isStart = false;
        private int _curWave = 0;
        
        private List<WaveData> _waveDataList = null;

        private void Start()
        {
            void OnComplete()
            {
                _isStart = true;
                StartCoroutine(StartStage());
            }

            Subscribe();
            LoadWaveData(OnComplete);
        }

        private void Subscribe()
        {
            enemyManager.OnEnemyCountChecked += OnGameBroken;
            enemyManager.OnEnemyCountChecked += enemyCountViewer.Set;
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
                
                _curWave = _curWave >= _waveDataList.Count ? _waveDataList.Count - 1 : _waveDataList[_curWave].Wave;
                waveTimeViewer.Set(_waveDataList[_curWave - 1].WaveTime);
                waveTimeViewer.OnCompleted += () => _isStart = true;
                waveViewer.Set(1);
                
                enemyManager.Create(_waveDataList[_curWave - 1]);
                
                _isStart = false;
            }
        }

        private void OnGameBroken(int aliveEnemyCount)
        {
            if (aliveEnemyCount < maxEnemyCount) return;
            
            Time.timeScale = 0;
                
            Debug.Log("Game Broken...");
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