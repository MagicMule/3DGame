using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGeneration2D : MonoBehaviour
{
    /// <summary>
    /// Generate a 2D grid
    /// </summary>
    /// 
    public class Cell
    {
        public bool visited = false;
    }

    [System.Serializable]
    public class RomeRule
    {
        public GameObject room;
    }

    List<Cell> board;
    public Vector2Int size;
    public int startPos = 0;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        board = new List<Cell>();

        for (int i = 0; i < size.x; i++)
        {
            for ( int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        foreach (Cell cell in board)
        {
            Debug.Log(cell);
        }
    } 
}
