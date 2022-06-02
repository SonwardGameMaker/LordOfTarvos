using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid
{
    public int _width;
    public int _height;
    public float _cellSize;
    public Node[,] _grid;

    public MyGrid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _grid = new Node[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                _grid[x, y] = new Node();

                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                //Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        //Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width, _height), Color.white, 100f);
        //Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width, _height), Color.white, 100f);
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / _cellSize);
        y = Mathf.FloorToInt(worldPosition.y / _cellSize);
    }
    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * _cellSize;
    }
    public void SetValue(int x, int y, Node value) // потім буду закидати посилання на об'єкт в вузол, а не створюати новий
    {
        if (x>=0 && x<_width && y>=0 && y<_height)
        {
            _grid[x, y] = value;
        }
    }
    public void SetValue(Vector3 worldPosition, Node value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public Node GetValue(int x, int y)
    {
        if (x >= 0 && x < _width && y >= 0 && y < _height)
        {
            return _grid[x, y];
        }
        else
            return null;
    }
    public Node GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
