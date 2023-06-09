using QuarterDefense.InGame.Player;
using UnityEngine;

namespace QuarterDefense.InGame.Pool
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private CharacterPool[] characterPools;

        public void UseCharacterPool(CharacterType type, CharacterRank rank)
        {
            switch (type)
            {
                case CharacterType.Ice : characterPools[0].SpawnCharacter(rank); break;
                case CharacterType.Fire : characterPools[1].SpawnCharacter(rank); break;
                case CharacterType.Lightning : characterPools[2].SpawnCharacter(rank); break;
            }
        }
    }
}