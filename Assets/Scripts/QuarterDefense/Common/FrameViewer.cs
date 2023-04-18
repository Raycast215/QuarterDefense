using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.Common
{
    // Scripted by Raycast
    // 2023.04.19
    // Frame 표시를 위한 클래스.
    
    public class FrameViewer : MonoBehaviour
    {
        private const float One = 1.0f;
        
        [SerializeField] private Text frameTextViewer = null;

        private void Update()
        {
            SetFrame();
        }

        private void SetFrame()
        {
            float frame = One / Time.deltaTime;

            frameTextViewer.text = $"FPS : {frame:N0}";
        }
    }
}