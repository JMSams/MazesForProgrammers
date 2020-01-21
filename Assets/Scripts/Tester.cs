using UnityEngine;
using System.Collections;

public class Tester : MonoBehaviour
{
    public UnityEngine.UI.Text text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grid grid = new Grid(7, 7);

            text.text = grid.ToString();
        }
    }
}
