using UnityEngine;

namespace QuarterDefense.InGame.Spawner
{
    // Scripted by Raycast
    // 2023. 06. 11
    // Character를 랜덤으로 소환하는 클래스입니다.
    
    public class CharacterRandomSpawn : MonoBehaviour
    {
        [SerializeField] private CharacterSpawner[] spawners;

        public void SpawnRandomCharacter()
        {
            int random = Random.Range(0, spawners.Length);
            
            spawners[random].RandomSpawn();
        }
    }
}