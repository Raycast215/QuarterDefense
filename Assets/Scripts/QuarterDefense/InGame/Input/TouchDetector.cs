using UnityEngine;
using UnityEngine.EventSystems;
using QuarterDefense.InGame.UI;

namespace QuarterDefense.InGame.Input
{
    public class TouchDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TouchArea touchArea = null;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            touchArea.OnTouched.Invoke(true, Color.gray);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            touchArea.OnTouched.Invoke(true, Color.red);
        }
    }
}