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
        GO();
    }

    public void GO()
    {
        grid = new MazeGrid(columnCount, rowCount);
        BinaryTree bt = new BinaryTree();
        bt.On(grid);
        output.text = grid.ToString();
    }
}
