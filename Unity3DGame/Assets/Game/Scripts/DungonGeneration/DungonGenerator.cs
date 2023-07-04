using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungonGenerator : MonoBehaviour
{
    /// <summary>
    /// sorce: https://www.youtube.com/watch?v=gHU5RQWbmWE&list=PLHiQ2hAa9m4vujtZGfJsXTH_-xa2c8ZVo&index=7
    /// </summary>
    public class Cell
    {
        public bool visited = false; // have the cell been visited?
        public bool[] status = new bool[4]; // bools for up, down, right and left
    }

    public Vector2 size; // The size of the dungon
    public int startPos = 0;
    public GameObject[] rooms; // Roomes to used to construct dungon
    public Vector2 offset; // distnace betwen generated rooms

    List<Cell> board; // the cells make up a 2D bord that represent dungon rooms

    // Start is called before the first frame update
    void Start()
    {
        MazeGenerator();
    }


    // Update is called once per frame
    void Update()
    {

    }

    void GenerateDungon()
    {
        for (int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                Cell currentCell = board[Mathf.FloorToInt(i + j * size.x)]; // The cell curently being built

                if (currentCell.visited) // if current cell visited, instatiate it
                {
                    int randomRoom = Random.Range(0, rooms.Length);
                    var newRoom = Instantiate(rooms[randomRoom], new Vector3(i * offset.x, 0, -j * offset.y), Quaternion.identity, transform).GetComponent<RoomBehavior>(); // Instatiate room and get its RoomBehavior component
                    newRoom.UpdateRoom(currentCell.status);

                    newRoom.name += " " + i + "-" + j;
                }
            }
        }
    }


    void MazeGenerator()
    {

        board = new List<Cell>();

        // Generate board made of Cells
         for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Cell());
            }
        }

         int currentCell = startPos; //select a startpos cell

        Stack<int> path = new Stack<int>(); // keep track of the path made up to current cell

        int k = 0;

        while (k < 1000)
        {
            k++;

            board[currentCell].visited = true; // note that the curentCell has been vissited


            if(currentCell == board.Count - 1) // last cell of board
            {
                break;
            }

            //Check the cell's neighbors
            List<int> neighbors = CheckNeighbors(currentCell);

            
            if (neighbors.Count == 0) // if NO available neighbors
            {
                if(path.Count == 0) // if last cell reached on curren path
                {
                    break; // dungon is complite, exsit loop
                }
                else // if threre are more cell
                {
                    currentCell = path.Pop(); // put curentCell in the back (?)
                }
            }
            else // if there ARE availble neighbors
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)]; // chose random neighbor

                if (newCell > currentCell) // if new cell is greater then currentCell, going up or right
                {
                    // Create a conencted opeing betwen current and new cell

                    //going right
                    if (newCell - 1 == currentCell)
                    {
                        board[currentCell].status[2] = true; // open right in curent cell

                        currentCell = newCell;

                        board[currentCell].status[3] = true; // open left in new cell
                    }
                    // going down
                    else
                    {
                        board[currentCell].status[1] = true;

                        currentCell = newCell;

                        board[currentCell].status[0] = true;
                    }
                }
                else // if new cell is lesser then currentCell, up or left
                {
                    //left
                    if (newCell + 1 == currentCell)
                    {
                        board[currentCell].status[3] = true;

                        currentCell = newCell;

                        board[currentCell].status[2] = true;
                    }
                    //up
                    else
                    {
                        board[currentCell].status[0] = true;

                        currentCell = newCell;

                        board[currentCell].status[1] = true;
                    }
                }
            }

        }
        GenerateDungon(); // use the generated cells to bouild a dungon
    }


    List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //Check up neighbor
        if (cell - size.x >= 0 && !board[Mathf.FloorToInt(cell - size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - size.x));
        }

        //Check down neighbor
        if (cell + size.x < board.Count && !board[Mathf.FloorToInt(cell + size.x)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + size.x));
        }

        //Check right neighbor
        if ((cell + 1) % size.x != 0 && !board[Mathf.FloorToInt(cell + 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell + 1));
        }

        //Check left neighbor
        if (cell % size.x != 0 && !board[Mathf.FloorToInt(cell - 1)].visited)
        {
            neighbors.Add(Mathf.FloorToInt(cell - 1));
        }

        return neighbors;
    }
}
