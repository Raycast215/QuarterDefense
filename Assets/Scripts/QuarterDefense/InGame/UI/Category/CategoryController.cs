using UnityEngine;

namespace QuarterDefense.InGame.UI.Category
{
    public class CategoryController : MonoBehaviour
    {
        [SerializeField] private CategoryTab[] categoryTabs;
        
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            foreach (var category in categoryTabs)
            {
                category.OnTabSelected += _ => AllUnselected();
            }

            AllUnselected();
            
            categoryTabs[0].SetActive(true);
        }

        private void AllUnselected()
        {
            foreach (var category in categoryTabs)
            {
                category.SetActive(false);
            }
        }
    }
}

