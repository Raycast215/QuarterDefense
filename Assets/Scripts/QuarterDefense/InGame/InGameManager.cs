using QuarterDefense.InGame.UI.Viewer;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class InGameManager : MonoBehaviour
    {
        private const int StartGold = 40;
        private const int SpawnCost = 10;
        private const int Count = 1;
        private const int GameBrokenEnemyCount = 10;
        
        [SerializeField] private WaveSystem waveSystem;
        [SerializeField] private EnemySystem enemySystem;
        [SerializeField] private PlayerSpawner playerSpawner;

        [SerializeField] private GoldViewer goldViewer;
        [SerializeField] private EnemyCountViewer enemyCountViewer;
        [SerializeField] private WaveViewer waveViewer;
        [SerializeField] private WaveTimeViewer waveTimeViewer;
        
        private void Start()
        {
            goldViewer.Set(StartGold);
            
            enemyCountViewer.Set();

            waveSystem.OnEnemyCreated += enemySystem.Create;
            waveSystem.OnEnemyCountIncreased += () => waveViewer.Set(Count);
            waveSystem.OnTimerStarted += waveTimeViewer.StartTimer;
            
            enemySystem.OnEnemyCreated += () => enemyCountViewer.Set(Count);
            enemySystem.OnEnemyCreated += () => GameBroken(enemySystem.GetEnemyCount());
            enemySystem.OnEnemyDestroyed += () => enemyCountViewer.Set(-Count);
            enemySystem.OnEnemyDestroyed += () => goldViewer.Set(SpawnCost);
            
            playerSpawner.OnGetGoldChecked += () => goldViewer.Gold;
            playerSpawner.OnCreateSuccessed += () => goldViewer.Set(-SpawnCost);
        }

        private void GameBroken(int curEnemyCount)
        {
            if(curEnemyCount < GameBrokenEnemyCount) return;

            Time.timeScale = 0;
        }
    }
}     