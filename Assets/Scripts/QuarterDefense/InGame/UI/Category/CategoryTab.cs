using System;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI.Category
{
    // Scripted by Raycast
    // 2023. 05. 31
    // 카테고리 탭 기능 클래스.
    
    public class CategoryTab : MonoBehaviour
    {
        public event Action<CategoryTab> OnTabSelected = delegate {  };
        
        [SerializeField] private GameObject selected;
        [SerializeField] private GameObject unselected;

        [SerializeField] private string tabName;
        [SerializeField] private Text[] tabNames;
        
        [SerializeField] private GameObject contents;

        private void Start()
        {
            SetName();
        }
        
        public void SetActive(bool isActive)
        {
            contents.SetActive(isActive);
            selected.SetActive(isActive);
            unselected.SetActive(!isActive);
        }

        public void OnClickCategory()
        {
            OnTabSelected.Invoke(this);
            
            SetActive(true);
        }
        
        private void SetName()
        {
            foreach (var tab in tabNames) { tab.text = tabName; }
        }
    }
}