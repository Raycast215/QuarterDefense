using System;
using System.Linq;
using QuarterDefense.Common;
using QuarterDefense.InGame.Pool;
using QuarterDefense.InGame.Upgrade;
using UnityEngine;
using UnityEngine.U2D.Animation;
using Random = UnityEngine.Random;

namespace QuarterDefense.InGame.Spawner
{
    // Scripted by Raycast
    // 2023. 06. 11
    // 속성에 따른 Spawner 클래스입니다.

    [Serializable] public class RankWeight
    {
        [SerializeField] private int normal;
        [SerializeField] private int rare;
        [SerializeField] private int unique;
        [SerializeField] private int legendary;

        private int[] _weights;

        public int[] Weights
        {
            get
            {
                if (_weights == null) Init();

                return _weights;
            }
        }

        private void Init()
        {
            _weights = new[] { normal, rare, unique, legendary };
        }
    }
    
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private Gold gold;
        [SerializeField] private RankWeight rankWeight;
        [SerializeField] private SpriteLibraryAsset[] spriteAssets;
    
        // Pool
        [SerializeField] private Player.Character characterPrefab;
        [SerializeField] private int capacity;
        [SerializeField] private Transform poolLayer;
        
        private Pooling<Player.Character> _characterPool;
        
        private int _maxRankWeight;

        private void Awake()
        {
            _characterPool = new Pooling<Player.Character>(characterPrefab, capacity, poolLayer);
            _characterPool.Pool();
        }

        private void Start() => SetMaxWeight();
        
        public void RandomSpawn()
        {
            if(gold.Amount < Constants.SpawnCost) return;

            int rankIndex = GetRandomTargetIndex();

            SetCharacter((Player.Character.CharacterRank)rankIndex);

            gold.Amount = -Constants.SpawnCost;
        }

        public void UpgradeRankToRare(BaseUpgrade toUpgrade)
        {
            UpgradeRank(toUpgrade.Cost, Player.Character.CharacterRank.Rare);
        }
        
        public void UpgradeRankToUnique(BaseUpgrade toUpgrade)
        {
            UpgradeRank(toUpgrade.Cost, Player.Character.CharacterRank.Unique);
        }

        public void UpgradeRankToLegendary(BaseUpgrade toUpgrade)
        {
            UpgradeRank(toUpgrade.Cost, Player.Character.CharacterRank.Legendary);
        }

        /// <summary>
        /// 가중치의 총 합을 저장합니다.
        /// </summary>
        private void SetMaxWeight()
        {
            foreach (var weight in rankWeight.Weights)
            {
                _maxRankWeight += weight;
            }
        }

        /// <summary>
        /// 랜덤으로 가중치에 해당하는 인덱스를 반환합니다.
        /// </summary>
        /// <returns></returns>
        private int GetRandomTargetIndex()
        {
            int random = Random.Range(0, _maxRankWeight);
            
            int ret = -1;

            // 가중치를 계산합니다.
            for (var i = 0; i < rankWeight.Weights.Length; i++)
            {
                int weight = rankWeight.Weights[i];
                random -= weight;

                if (random > 0) continue;

                ret = i;

                return ret;
            }

            return ret;
        }
        
        /// <summary>
        /// 랭크 업그레이드를 실행합니다.
        /// </summary>
        /// <param name="targetRank"></param>
        /// <param name="onComplete"></param>
        private void RankUp(Player.Character.CharacterRank toRank, Action onComplete)
        {
            // 소모될 랭크의 캐릭터들만 담아둔 리스트를 만듭니다.
            var toList = poolLayer.GetComponentsInChildren<Player.Character>()
                .Where(x => x.gameObject.activeInHierarchy)
                .Where(x => x.Rank.Equals(toRank))
                .ToList();

            // 리스트의 수와 소모될 캐릭터의 수와 비교합니다.
            if(toList.Count < Constants.RankUpCharacterCount) return;
            
            // 소모된 캐릭터들을 풀링에 추가합니다.
            foreach (var character in toList)
            {
                _characterPool.Return(character);
            }
            
            // 마지막으로 실행할 함수를 실행합니다.
            onComplete.Invoke();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="toCost"></param>
        /// <param name="toRank"></param>
        private void UpgradeRank(int toCost, Player.Character.CharacterRank toRank)
        {
            void Complete()
            {
                SetCharacter(toRank);
                
                gold.Amount = -toCost;
            }
            
            if(gold.Amount < toCost) return;
            
            RankUp(toRank - 1, Complete);
        }
        
        /// <summary>
        /// 캐릭터를 랭크에 맞게 저장합니다.
        /// </summary>
        /// <param name="toRank"></param>
        private void SetCharacter(Player.Character.CharacterRank toRank)
        {
            Player.Character toCharacter = _characterPool.Get();
            toCharacter.CharacterSprite = spriteAssets[(int)toRank];
            toCharacter.Rank = toRank;
                
            toCharacter.OnDied -= _characterPool.Return;
            toCharacter.OnDied += _characterPool.Return;

            toCharacter.transform.position = Vector3.zero;
            
            toCharacter.gameObject.SetActive(true);
        }
    }
}