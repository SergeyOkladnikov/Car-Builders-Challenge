using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyPanel : MonoBehaviour
{
    [SerializeField]
    private int rows = 4;
    [SerializeField]
    private int cols = 8;
    [SerializeField]
    private AssemblyCell[,] _grid = new AssemblyCell[4, 8];

    private void Start()
    {
        MakeGrid();
    }
    private void MakeGrid()
    {
        AssemblyCell[] cells = GetComponentsInChildren<AssemblyCell>();
        _grid = new AssemblyCell[rows, cols];
        foreach (AssemblyCell cell in cells)
        {
            //Debug.Log($"{cell.position.x}, {cell.position.y}");
            _grid[(int)cell.position.x, (int)cell.position.y] = cell;
        }
       
    }

    public PartInfo[,] GetBuildData()
    {
        PartInfo[,] parts = new PartInfo[rows, cols];
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                parts[row, col] = GetComponentInChildren<BuildBlock>().partInfo;
            }
        }
        return parts;
    }
}
