using System;
using System.Collections;
using System.Collections.Generic;
using QuarterDefense.InGame.UI.Viewer;
using UnityEngine;

namespace QuarterDefense.InGame
{
    // Scripted by Raycast
    // 2023. 06. 12
    // 웨이브 데이터를 담은 클래스입니다.
    
    public class WaveData
    {
        public int Wave;
        public float WaveTime;
        public string EnemyID;
        public int CreateCount;
        public float Hp;
        public string Tag;
    }
    
    // Scripted by Raycast
    // 2023. 06. 12
    // 웨이브를 실행하는 로직을 담은 클래스입니다.
    
    public class WaveSystem : MonoBehaviour
    {
        private const string CsvPath = "CSV/WaveDataSheet";

        public event Action<float> OnTimerStarted = delegate {  }; 
        public event Action<WaveData> OnEnemyCreated = delegate {  };
        public event Action OnEnemyCountIncreased = delegate {  };

        [SerializeField] private WaveTimeViewer waveTimeViewer;

        private bool _isStart;
        private int _curWave;
        
        private List<WaveData> _waveDataList;

        private void Start()
        {
            void OnComplete()
            {
                _isStart = true;
                StartCoroutine(StartWave());
            }
            
            LoadWaveData(OnComplete);
        }

        /// <summary>
        /// 웨이브 정보를 로드합니다.
        /// </summary>
        /// <param name="onComplete"></param>
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
                    Wave = int.Parse($"{data["Wave"]}"),
                    WaveTime = float.Parse($"{data["Time"]}"),
                    EnemyID = $"{data["ID"]}",
                    CreateCount = int.Parse($"{data["CreateCount"]}"),
                    Hp = float.Parse($"{data["Hp"]}"),
                    Tag = $"{data["Tag"]}"
                });
            }
            
            onComplete.Invoke();
        }

        /// <summary>
        /// 웨이브를 실행합니다.
        /// </summary>
        /// <returns></returns>
        private IEnumerator StartWave()
        {
            while (true)
            {
                yield return new WaitUntil(() => _isStart);
                
                // 마지막 웨이브 반복하도록 임시 작업.
                _curWave = _curWave >= _waveDataList.Count 
                    ? _waveDataList.Count - 1
                    : _waveDataList[_curWave].Wave;
               
                OnTimerStarted.Invoke(_waveDataList[_curWave - 1].WaveTime);
                OnEnemyCountIncreased.Invoke();
                OnEnemyCreated.Invoke(_waveDataList[_curWave - 1]);
                
                waveTimeViewer.OnCompleted += () => _isStart = true;

                _isStart = false;
            }
        }
    }
}