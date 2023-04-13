using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuarterDefense.InGame
{
    public delegate void TileHandler(List<Tile> toList);
    
    public class TileCreator : MonoBehaviour
    {
        private const int TileCount = 9;
        private const float Half = 0.5f;
        
        public event TileHandler OnTileCreated = delegate(List<Tile> list) {  };

        [SerializeField] private Tile tilePrefab = null;
        
        public void CreateTile()
        {
            // Tile의 중앙 값에 맞춰 Offset 조절.
            float offset = (TileCount - 1) * Half;

            // Tile List 생성.
            List<Tile> tileList = new List<Tile>();
            
            for (int i = 0; i < TileCount; i++)
            {
                for (int j = 0; j < TileCount; j++)
                {
                    Tile newTile = Instantiate(tilePrefab, gameObject.transform, true);
                    
                    newTile.transform.position = new Vector3(i - offset, -Half, j - offset);
                    newTile.gameObject.SetActive(false);
                    
                    tileList.Add(newTile);
                }
            }

            // Tile List 전달하기 위한 이벤트 실행.
            OnTileCreated.Invoke(tileList);
        }
    }
}