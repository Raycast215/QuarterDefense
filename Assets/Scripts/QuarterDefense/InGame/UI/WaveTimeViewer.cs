using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    public class WaveTimeViewer : MonoBehaviour
    {
        private const float Min = 60.0f;
        
        public event Action OnCompleted = delegate {  }; 
        
        [SerializeField] private Text waveTimeText = null;

        private float _curTime = 0.0f;

        private Coroutine _waveTimeRoutine = null;
        
        public void Set(float toWaveTime)
        {
            if(_waveTimeRoutine != null) StopCoroutine(_waveTimeRoutine);
            _waveTimeRoutine = StartCoroutine(OnTimer(toWaveTime));
        }

        private IEnumerator OnTimer(float toTime)
        {
            _curTime = toTime;

            SetText("00", "00");
            
            while (_curTime > 0.0f)
            {
                _curTime -= Time.deltaTime * Time.timeScale;
                
                string ms = $"{Mathf.Floor(_curTime / Min):00}";
                string ss = $"{_curTime % Min:00}";

                SetText(ms, ss);
                
                yield return null;
            }
            
            SetText("00", "00");
            
            OnCompleted.Invoke();
        }

        private void SetText(string m, string s)
        {
            waveTimeText.text = $"{m} : {s}";
        }
    }
}

