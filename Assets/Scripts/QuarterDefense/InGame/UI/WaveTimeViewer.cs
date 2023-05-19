using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    public class WaveTimeViewer : MonoBehaviour
    {
        [SerializeField] private Text countdownText = null;

        private float _curTime = 0.0f;
        
        public void Set(float toWaveTime)
        {
            
        }

        // private IEnumerator OnTimer(float toTime)
        // {
        //     _curTime -= Time.deltaTime;
        //     
        //     
        //     
        // }
    }

}

