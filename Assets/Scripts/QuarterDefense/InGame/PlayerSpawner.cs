using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class PlayerSpawner : MonoBehaviour
    {
        private const string PrefabPath = "InGame/Player/Prefabs";
        
        private List<Player.Player> _playerList = new List<Player.Player>();
        private Player.Player[] _playerPrefabs = null;

        private void Start()
        {
            SetPlayerPrefabList();
        }

        public void CreateCharacter()
        {
            Player.Player player = Instantiate(GetRandomPlayerPrefab(), transform);
            
            _playerList.Add(player);
        }

        private void SetPlayerPrefabList()
        {
            _playerPrefabs = Resources.LoadAll<Player.Player>($"{PrefabPath}");
        }

        private Player.Player GetRandomPlayerPrefab()
        {
            int random = UnityEngine.Random.Range(0, _playerPrefabs.Length);

            return _playerPrefabs[random];
        }
    }
}


