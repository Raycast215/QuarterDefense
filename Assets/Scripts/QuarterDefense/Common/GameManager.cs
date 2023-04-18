using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.Common
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            #if UNITY_ANDROID
            
            Application.targetFrameRate = 60;
            
            #endif

            QualitySettings.vSyncCount = 1;
        }
    }
}