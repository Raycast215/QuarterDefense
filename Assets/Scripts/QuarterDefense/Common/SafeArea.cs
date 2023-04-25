using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.Common
{
    // Scripted by Raycast
    // 2023.04.25
    // 스마트폰의 노치 대응용 클래스.
    
    public class SafeArea : MonoBehaviour
    {
        private RectTransform _targetTransform;
        private Rect _safeArea;
        private Vector2 _minAnchor;
        private Vector2 _maxAnchor;

        private void Awake()
        {
            _targetTransform = GetComponent<RectTransform>();
            
            _safeArea = Screen.safeArea;
            _minAnchor = _safeArea.position;
            _maxAnchor = _minAnchor + _safeArea.size;

            _minAnchor.x /= Screen.width;
            _minAnchor.y /= Screen.height;
            _maxAnchor.x /= Screen.width;
            _maxAnchor.y /= Screen.height;

            _targetTransform.anchorMin = _minAnchor;
            _targetTransform.anchorMax = _maxAnchor;
        }
    }
}