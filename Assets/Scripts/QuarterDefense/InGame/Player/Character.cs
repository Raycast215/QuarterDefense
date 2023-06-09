using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace QuarterDefense.InGame.Player
{
    public class Character : MonoBehaviour
    {
        public CharacterType CharacterType { private get; set; }
        public CharacterRank CharacterRank { private get; set; }
        public SpriteLibraryAsset CharacterSprite { private get; set; }
        
        
    }
}