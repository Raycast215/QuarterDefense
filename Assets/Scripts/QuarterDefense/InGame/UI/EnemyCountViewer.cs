using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuarterDefense.InGame.UI
{
    public class EnemyCountViewer : MonoBehaviour
    {
        [SerializeField] private Text enemyCountText = null;

        public void Set(int enemyCount)
        {
            enemyCountText.text = $"{enemyCount} / 256";
        }
    }
}