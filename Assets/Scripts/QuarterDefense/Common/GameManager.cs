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
            
            #elif UNITY_EDITOR
            
            Application.targetFrameRate = -1;
            
            #endif

            QualitySettings.vSyncCount = 1;
        }
    }
}