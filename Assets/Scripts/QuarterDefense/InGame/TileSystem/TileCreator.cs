using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuarterDefense.Common;

namespace QuarterDefense.InGame.TileSystem
{
    public delegate void TileHandler(List<Tile> toList);
    
    public class TileCreator : MonoBehaviour
    {
        private const float Half = 0.5f;

        public event TileHandler OnTileCreated = delegate(List<Tile> list) {  };
        
        private Tile _tileTRoad = null;
        private Tile _tileBackground = null;
        
        private readonly List<Vector2> _enemyTilePosList = new List<Vector2>()
        {
            new Vector2(0,4), new Vector2(4,0),
            new Vector2(1,4), new Vector2(4,1),
            new Vector2(2,4), new Vector2(4,2),
            new Vector2(3,4), new Vector2(4,3),
            new Vector2(4,4),
            new Vector2(5,4), new Vector2(4,5),
            new Vector2(6,4), new Vector2(4,6),
            new Vector2(7,4), new Vector2(4,7),
            new Vector2(8,4), new Vector2(4,8),
        };

        private void Start()
        {
            LoadTile("Default");
        }

        public void CreateTile()
        {
            // Tile의 중앙 값에 맞춰 Offset 조절.
            float offset = (Constants.TileLength - 1) * Half;

            // Tile List 생성.
            List<Tile> tileList = new List<Tile>();
            
            for (int i = 0; i < Constants.TileLength; i++)
            {
                for (int j = 0; j < Constants.TileLength; j++)
                {
                    // Road Tile 위치 비교용.
                    Vector2 pos = new Vector2(i, j);

                    // 프리팹 설정.
                    Tile tilePrefab = _enemyTilePosList.Contains(pos) ? _tileTRoad : _tileBackground;
                    // 인스턴스 생성.
                    Tile newTile = Instantiate(tilePrefab, gameObject.transform, true);
                    
                    newTile.transform.position = new Vector3(i - offset, -Half, j - offset);

                    tileList.Add(newTile);
                }
            }

            // Tile List 전달하기 위한 이벤트 실행.
            OnTileCreated.Invoke(tileList);
        }

        private void LoadTile(string tileName)
        {
            _tileTRoad = Resources.Load<Tile>($"{Constants.TilePrefabPath}/Tile_{tileName}_A");
            _tileBackground = Resources.Load<Tile>($"{Constants.TilePrefabPath}/Tile_{tileName}_B");
        }
    }
}