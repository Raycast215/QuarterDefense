using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.Common
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool isDebugMode = false;
        
        private void Awake()
        {
            QualitySettings.vSyncCount = 1;
            
#if UNITY_ANDROID
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
#else
            Application.targetFrameRate = -1;
#endif
        }
    }
}