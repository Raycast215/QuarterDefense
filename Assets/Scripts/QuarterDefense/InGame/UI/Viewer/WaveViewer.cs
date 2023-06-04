using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI.Viewer
{
    // Scripted by Raycast
    // 2023. 05. 09
    // Wave를 UI에 표시하는 클래스입니다.
    
    public class WaveViewer : Viewer
    {
        [SerializeField] private Text waveText;
        
        private int _wave;
        
        public override void Set(int value = 0)
        {
            _wave += value;
            
            waveText.text = $"Wave {_wave}";
        }
    }
}