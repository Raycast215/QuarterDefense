using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public class TileManager : MonoBehaviour
    {
        [SerializeField] private TileCreator tileCreator = null;
        [SerializeField] private TileStartEffect tileStartEffect = null;

        private List<Tile> _tileList = new List<Tile>();
        
        private void Start()
        {
            tileCreator.OnTileCreated += toList => _tileList = toList;
            tileCreator.OnTileCreated += tileStartEffect.PlayStartEffect;
            tileCreator.CreateTile();
        }
    }
}
