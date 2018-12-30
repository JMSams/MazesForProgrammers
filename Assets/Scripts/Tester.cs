using Mazes_for_Programmers;
using Mazes_for_Programmers.MazeAlgorithms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public TMPro.TextMeshProUGUI output;

    [Range(3, 32)]
    public int columnCount = 3;

    [Range(3, 32)]
    public int rowCount = 3;

    MazeGrid grid;

    private void Start()
    {
        grid = new MazeGrid(columnCount, rowCount);
        output.text = grid.ToString();
    }

    public void BinaryTree()
    {
        GO<BinaryTree>();
    }

    public void RecursiveBacktracker()
    {
        GO<RecursiveBacktracker>();
    }

    void GO<T>() where T : AlgorithmBase, new()
    {
        grid = new MazeGrid(columnCount, rowCount);
        T algorithm = new T();
        algorithm.On(ref grid);
        output.text = grid.ToString();
    }
}
