using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Wave를 UI에 표시하는 클래스입니다.
    
    public class WaveViewer : Viewer
    {
        [SerializeField] private Text waveText = null;

        private int _wave = 0;
        
        public override void Set(int delta)
        {
            _wave += delta;
            
            waveText.text = $"Wave {_wave}";
            
            Debug.Log($"Start {_wave} Wave...!");
        }
    }
}