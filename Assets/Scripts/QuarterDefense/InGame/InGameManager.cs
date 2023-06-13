using QuarterDefense.Common;
using QuarterDefense.InGame.UI.Viewer;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class InGameManager : MonoBehaviour
    {
        private const int StartGold = 4000000;
        private const int Count = 1;

        [Header("System")]
        [SerializeField] private WaveSystem waveSystem;
        [SerializeField] private EnemySystem enemySystem;
        [SerializeField] private Gold gold;
        
        [Header("Viewer")]
        [SerializeField] private GoldViewer goldViewer;
        [SerializeField] private EnemyCountViewer enemyCountViewer;
        [SerializeField] private WaveViewer waveViewer;
        [SerializeField] private WaveTimeViewer waveTimeViewer;
        
        private void Start()
        {
            goldViewer.SetText(StartGold);

            gold.Amount = StartGold;
            gold.OnGoldViewerChanged += goldViewer.SetText;
            
            enemyCountViewer.SetMaxEnemyCount(Constants.MaxEnemyCount);
            enemyCountViewer.Set();

            waveSystem.OnEnemyCreated += enemySystem.Create;
            waveSystem.OnEnemyCountIncreased += () => waveViewer.Set(Count);
            waveSystem.OnTimerStarted += waveTimeViewer.StartTimer;
            
            enemySystem.OnEnemyCreated += () => enemyCountViewer.Set(Count);
            enemySystem.OnEnemyCreated += () => GameBroken(enemySystem.GetEnemyCount());
            enemySystem.OnEnemyDestroyed += () => enemyCountViewer.Set(-Count);
            enemySystem.OnEnemyDestroyed += () => gold.Amount = Constants.SpawnCost;
        }

        private void GameBroken(int curEnemyCount)
        {
            if(curEnemyCount < Constants.MaxEnemyCount) return;

            Time.timeScale = 0;
        }
    }
}     