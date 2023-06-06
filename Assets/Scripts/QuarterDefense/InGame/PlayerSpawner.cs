using System;
using System.Collections.Generic;
using QuarterDefense.InGame.Player;
using UnityEngine;

namespace QuarterDefense.InGame
{
    [Serializable] public class CharacterData
    {
        public PlayerRank rank;
        public string characterName;
        public Player.Player prefab;
        public int weight;
    }

    public class PlayerSpawner : MonoBehaviour
    {
        private const int MinNeedGold = 10;
        
        public event Action OnCreateSuccessed = delegate {  };
        
        private List<Player.Player> _playerList = new List<Player.Player>();

        [SerializeField] private Gold gold;
        [SerializeField] private CharacterData[] characterData;

        private int _maxWeight;
        
        private void Start()
        {
            CalculateMaxWeight();
        }

        public void CreateCharacter()
        {
            if(gold.Amount < MinNeedGold) return; 
            
            OnCreateSuccessed.Invoke();
            
            Player.Player player = Instantiate(GetRandomPlayerPrefab(), transform);
            
            _playerList.Add(player);
        }

        private void CalculateMaxWeight()
        {
            foreach (var data in characterData)
            {
                _maxWeight += data.weight;
            }
        }
        
        private Player.Player GetRandomPlayerPrefab()
        {
            int random = UnityEngine.Random.Range(0, _maxWeight);
           
            foreach (var data in characterData)
            {
                random -= data.weight;

                if (random > 0) continue;
                
                return data.prefab;
            }

            return null;
        }

        private void SpawnCharacter(PlayerRank rank)
        {
            Player.Player player = Instantiate(GetRandomPlayerPrefab(), transform);
        }

        private void UpgradeCharacter(PlayerRank rank)
        {
            if(rank.Equals(PlayerRank.Normal)) return;
            
            
        }
    }
}