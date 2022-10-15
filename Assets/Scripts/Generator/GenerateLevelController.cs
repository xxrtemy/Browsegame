using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateLevelController 
{
    private const int CountWall = 4;
    
    
    private Tilemap _tileMapGround;
    private Tile _tileGround;
    private int _wightMap;
    private int _heightMap;
    private int _factorSmooth;
    private int _randomFillPercent;


    private int[,] _map;


    public GenerateLevelController (GenerateLevelView view)
    {
        _tileMapGround = view.TileMapGround;
        _tileGround = view.TileGround;
        _wightMap = view.WightMap;
        _heightMap = view.HeightMap;
        _factorSmooth = view.FactorSmooth;
        _randomFillPercent = view.RandomFillPercent;

        _map = new int[_wightMap, _heightMap];
    }


    public void Awake()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        RandomFillLevel();

        for (var i = 0; i < _factorSmooth; i++)
            SmoothMap();

        DrawTilesOnMap();
    }

    private void RandomFillLevel()
    {
        var seed = Time.time.ToString();
        var psevdoRandom = new System.Random(seed.GetHashCode());

        for (var x = 0; x < _wightMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                if (x == 0 || x == _wightMap - 1 || y == 0 || y == _heightMap - 1)
                    _map[x, y] = 1;
                else
                    _map[x, y] = (psevdoRandom.Next(0, 100) < _randomFillPercent) ? 1 : 0;
            }
        }
    }

    private void SmoothMap()
    {
        for (var x = 0; x < _wightMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var neighbourWallTiles = GetNeighbourWall(x, y);

                if (neighbourWallTiles > CountWall)
                    _map[x, y] = 1;
                else if (neighbourWallTiles < CountWall)
                    _map[x, y] = 0;
            }
        }
    }

    private int GetNeighbourWall(int x, int y)
    {
        var wallCount = 0;

        for (var neighbourX = x - 1; neighbourX <= x + 1; neighbourX++)
        {
            for (var neighbourY = y - 1; neighbourY <= y + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < _wightMap && neighbourY >= 0 && neighbourY < _heightMap)
                {
                    if (neighbourX != x || neighbourY != y)
                        wallCount += _map[neighbourX, neighbourY];
                }
                else
                {
                    wallCount++;
                }

            }
        }

        return wallCount;
    }
    
    private void DrawTilesOnMap()
    {
        if (_map == null)
            return;

        for (var x = 0; x < _wightMap; x++)
        {
            for (var y = 0; y < _heightMap; y++)
            {
                var positionTile = new Vector3Int(-_wightMap / 2 + x, -_heightMap / 2 + y, 0);

                if (_map[x, y] == 1)
                    _tileMapGround.SetTile(positionTile, _tileGround);
            }
        }
    }
}
