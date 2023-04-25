using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace QuarterDefense.Common
{
    // Scripted by Raycast
    // 2023.04.26
    // 버튼 클릭 시 사용되는 공통 클래스입니다.
    
    public class Button : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject select = null;

        public void OnPointerDown(PointerEventData eventData)
        {
            select.SetActive(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            select.SetActive(false);
        }
    }
}