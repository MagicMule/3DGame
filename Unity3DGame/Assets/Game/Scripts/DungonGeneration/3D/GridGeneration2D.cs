using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneration2D : MonoBehaviour
{
    /// <summary>
    /// Generate a 2D grid
    /// </summary>
    /// 
    public class Cell
    {
        public bool visited = false;
        public bool[] status = new bool[4]; // Up, Down, Right, Left
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

        for (int i = 0; i < size.x; i++) // This for loop makes a complite rectangular grid made of cells
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

        int currentCell = startPos; // selekting a start possiton, statring cell to look at, on the grid 

        Stack<int> path = new Stack<int>();

        int k = 0;

        while (k < 1000)
        {
            k++;

            board[currentCell].visited = true; //We are vissiting the curent cell

            List<int> neighbors = CheckNeighbors(currentCell); //check the current neigbors for current cell


            if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop(); // Set the int value of currentCell to int value on top of the "path" stack
                }
            }
            else
            {
                path.Push(currentCell); 

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    //down or right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true;
                        currentCell = newCell;
                        board[currentCell].status[3] = true;
                    }
                    else
                    {
                        board[currentCell].status[1] = true;
                        currentCell = newCell;
                        board[currentCell].status[0] = true;
                    }
                }
                else
                {
                    //up or left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;
                        currentCell = newCell;
                        board[currentCell].status[2] = true;
                    }
                    else
                    {
                        board[currentCell].status[0] = true;
                        currentCell = newCell;
                        board[currentCell].status[1] = true;
                    }
                }

            }

        }
    }
    List<int> CheckNeighbors(int cell)
    {
        /*
         * We check if neigbors, up, down, left, right, are available.
         * That is we check if we are in bounds of the grid and if we have visited the neighbor befor the current check
         */

        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[(cell - size.x)].visited)
        {
            neighbors.Add((cell - size.x));
        }

        //check down neighbor
        if (cell + size.x < board.Count && !board[(cell + size.x)].visited)
        {
            neighbors.Add((cell + size.x));
        }

        //? seems that ((cell + 1) % size.x) and (cell % size.x != 0) is used do difine right and left 
        //check right neighbor
        if ((cell + 1) % size.x != 0 && !board[(cell + 1)].visited)
        {
            neighbors.Add((cell + 1));
        }

        //check left neighbor
        if (cell % size.x != 0 && !board[(cell - 1)].visited)
        {
            neighbors.Add((cell - 1));
        }
        //Debug.Log(board.Count);

        return neighbors;
    }
}
