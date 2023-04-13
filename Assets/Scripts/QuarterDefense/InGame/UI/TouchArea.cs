using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    public class TouchArea : MonoBehaviour
    {
        private const float Alpha = 0.5f;
     
        public Action<bool, Color> OnTouched = delegate(bool b, Color color) {  };
        
        [SerializeField] private Image touchArea = null;
        
        private Color _color = Color.clear;

        private void Start()
        {
            Subscribe();
        }

        private void Subscribe()
        {
            OnTouched += SetColor;
        }

        private void SetColor(bool isSelected, Color color)
        {
            _color = color;
            _color.a = Alpha;
            touchArea.color = _color;
        }
    }
}