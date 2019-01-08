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
    
    public float delayTime = 0.01f;

    MazeGrid grid;

    bool isRunning = false;

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
        Debug.Log("Starting maze algorithm, isRunning == " + isRunning);

        if (isRunning)
        {
            Debug.Log("Already running, exiting...");
            return;
        }

        isRunning = true;

        grid = new MazeGrid(columnCount, rowCount);
        T algorithm = new T();
        StartCoroutine(algorithm.On(grid, this));
    }

    internal void AlgorithmComplete()
    {
        isRunning = false;
    }
}
