using System.Collections.Generic;
using System.Linq;
using QuarterDefense.InGame.Interface;
using QuarterDefense.InGame.Player;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace QuarterDefense.InGame.Pool
{
    // Scripted by Raycast
    // 2023. 06. 09
    // Character Object를 관리하는 Pool 클래스.
    
    public class CharacterPool : MonoBehaviour, IPool
    {
        private const int MaxPlayerCount = 32;

        [SerializeField] private CharacterType type;
        [SerializeField] private Player.Character characterPrefab;
        [SerializeField] private SpriteLibraryAsset[] spriteAssets;
        
        private List<Player.Character> _characterPoolList;

        private void Start()
        {
            _characterPoolList = new List<Player.Character>();
        }

        /// <summary>
        /// 사용 가능한 Character를 소환합니다.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public void SpawnCharacter(CharacterRank rank)
        {
            // List의 수가 최대 수량보다 적은 경우 Character 생성.
            if (_characterPoolList.Count < MaxPlayerCount)
            {
                CreateCharacter(rank); 
                return;
            }
            
            foreach (var character in _characterPoolList.Where(x => !x.gameObject.activeInHierarchy))
            {
                InitCharacter(character, rank);
                break;
            }
        }

        /// <summary>
        /// 받아온 Rank가 일치하고, object가 활성화된 Character를 반환합니다.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public Player.Character GetCharacter(CharacterRank rank)
        {
            return _characterPoolList
                .Where(x => rank.Equals(x.CharacterRank))
                .FirstOrDefault(x => x.gameObject.activeInHierarchy);
        }
        
        /// <summary>
        /// ObjectPool List에서 초과된 Object 수 만큼 삭제합니다. 
        /// </summary>
        public void DestroyPool()
        {
            foreach (var character in _characterPoolList.Where(x => !x.gameObject.activeInHierarchy))
            {
                if(_characterPoolList.Count < MaxPlayerCount) break;

                _characterPoolList.Remove(character);
                Destroy(character.gameObject);
            }
        }

        /// <summary>
        /// Character를 생성합니다.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        private void CreateCharacter(CharacterRank rank)
        {
            Player.Character character = Instantiate(characterPrefab, transform);
            
            _characterPoolList.Add(character);

            InitCharacter(character, rank);
        }

        /// <summary>
        /// Character를 초기화 합니다.
        /// </summary>
        /// <param name="toCharacter"></param>
        /// <param name="rank"></param>
        private void InitCharacter(Player.Character toCharacter, CharacterRank rank)
        {
            toCharacter.gameObject.SetActive(true);
            toCharacter.CharacterType = type;
            toCharacter.CharacterRank = rank;
            toCharacter.CharacterSprite = GetSpriteLibraryAsset(rank);
        }

        /// <summary>
        /// CharacterRank에 따른 SpriteLibraryAsset를 반환합니다.
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        private SpriteLibraryAsset GetSpriteLibraryAsset(CharacterRank rank)
        {
            SpriteLibraryAsset ret = rank switch
            {
                CharacterRank.Normal => spriteAssets[0],
                CharacterRank.Rare => spriteAssets[1],
                CharacterRank.Unique => spriteAssets[2],
                CharacterRank.Legendary => spriteAssets[3],
                _ => null
            };

            return ret;
        }
    }
}