using System;
using Mazes_for_Programmers;
using Mazes_for_Programmers.MazeAlgorithms;
using UnityEngine;

public class Tester : MonoBehaviour
{
    #region Sprites
    public Sprite sprites_none;
    public Sprite sprites_north;
    public Sprite sprites_east;
    public Sprite sprites_south;
    public Sprite sprites_west;
    public Sprite sprites_north_south;
    public Sprite sprites_east_west;
    public Sprite sprites_north_east;
    public Sprite sprites_north_west;
    public Sprite sprites_south_east;
    public Sprite sprites_south_west;
    public Sprite sprites_north_east_west;
    public Sprite sprites_south_east_west;
    public Sprite sprites_east_north_south;
    public Sprite sprites_west_north_south;
    public Sprite sprites_north_south_east_west;
    #endregion

    [Range(3, 80)]
    public int columnCount = 3;

    [Range(3, 80)]
    public int rowCount = 3;

    [Range(0.001f, 0.3f)]
    [SerializeField]
    private float _delayTime;
    public float delayTime
    {
        get => _delayTime;
        set => _delayTime = value;
    }

    MazeGrid grid;

    Coroutine currentRun;
    bool isRunning { get => currentRun != null; }

    SpriteRenderer[,] sprites;

    private void Start()
    {
        grid = new MazeGrid(columnCount, rowCount);

        CreateNewSprites();

        OutputMaze(grid);
    }

    public void BinaryTree()
    {
        GO<BinaryTree>();
    }

    public void RecursiveBacktracker()
    {
        GO<RecursiveBacktracker>();
    }

    public void Kruskal()
    {
        GO<Kruskal>();
    }

    public void CancelRun()
    {
        if (!isRunning) return;

        this.StopCoroutine(currentRun);
    }

    void GO<T>() where T : AlgorithmBase, new()
    {
        if (isRunning)
        {
            Debug.Log("Algorithm is already running...");
            return;
        }

        grid = new MazeGrid(columnCount, rowCount);

        CreateNewSprites();

        T algorithm = new T
        {
            OnComplete = () =>
            {
                OutputMaze(this.grid);
                currentRun = null;
            },
            OnDraw = OutputMaze
        };

        currentRun = StartCoroutine(algorithm.On(grid, this));
    }

    void CreateNewSprites()
    {
        if (sprites != null)
        {
            for (int x = 0; x < sprites.GetLength(0); x++)
            {
                for (int y = 0; y < sprites.GetLength(1); y++)
                {
                    DestroyImmediate(sprites[x, y]);
                }
            }
        }
        sprites = new SpriteRenderer[columnCount, rowCount];
        for (int x = 0; x < grid.columnCount; x++)
        {
            for (int y = 0; y < grid.rowCount; y++)
            {
                sprites[x, y] = new GameObject(string.Format("Cell ({0}, {1})", x, y)).AddComponent<SpriteRenderer>();
                sprites[x, y].transform.SetParent(transform);
                sprites[x, y].transform.localPosition = new Vector3(x, 0 - y);
                sprites[x, y].transform.localScale = Vector3.one;
                sprites[x, y].sprite = CellToSprite(grid, grid[x, y]);
                sprites[x, y].color = Color.black;
            }
        }
    }

    void OutputMaze(MazeGrid grid)
    {
        for (int x = 0; x < grid.columnCount; x++)
        {
            for (int y = 0; y < grid.rowCount; y++)
            {
                sprites[x, y].sprite = CellToSprite(grid, grid[x, y]);
                sprites[x, y].color = grid[x, y].colour;
            }
        }
    }

    Sprite CellToSprite(MazeGrid grid, Cell cell)
    {
        Directions direction = Directions.nill;

        if (cell.IsLinked(grid[cell.column, cell.row - 1]))
            direction |= Directions.north;

        if (cell.IsLinked(grid[cell.column, cell.row + 1]))
            direction |= Directions.south;

        if (cell.IsLinked(grid[cell.column + 1, cell.row]))
            direction |= Directions.east;

        if (cell.IsLinked(grid[cell.column - 1, cell.row]))
            direction |= Directions.west;

        #region sprite output
        if (direction == Directions.north)
            return sprites_north;
        else if (direction == Directions.east)
            return sprites_east;
        else if (direction == Directions.south)
            return sprites_south;
        else if (direction == Directions.west)
            return sprites_west;
        else if (direction == (Directions.north | Directions.east))
            return sprites_north_east;
        else if (direction == (Directions.north | Directions.west))
            return sprites_north_west;
        else if (direction == (Directions.south | Directions.east))
            return sprites_south_east;
        else if (direction == (Directions.south | Directions.west))
            return sprites_south_west;
        else if (direction == (Directions.north | Directions.south))
            return sprites_north_south;
        else if (direction == (Directions.east | Directions.west))
            return sprites_east_west;
        else if (direction == (Directions.north | Directions.east | Directions.west))
            return sprites_north_east_west;
        else if (direction == (Directions.south | Directions.east | Directions.west))
            return sprites_south_east_west;
        else if (direction == (Directions.north | Directions.south | Directions.east))
            return sprites_east_north_south;
        else if (direction == (Directions.north | Directions.south | Directions.west))
            return sprites_west_north_south;
        else if (direction == (Directions.north | Directions.east | Directions.south | Directions.west))
            return sprites_north_south_east_west;
        else
            return sprites_none;
        #endregion
    }
}
