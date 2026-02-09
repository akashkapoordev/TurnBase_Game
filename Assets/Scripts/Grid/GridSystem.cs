using UnityEngine;

public class GridSystem 
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width ,int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for(int x = 0; x<width;x++)
        {
            for(int z = 0;z<height;z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectArray[x, z] = new GridObject(this, gridPosition);

            }
        }

    }

    public Vector3 GetGridWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0, gridPosition.z) * cellSize;
    }

    public GridPosition GetGridPosition(Vector3 worldPositon)
    {
        return new GridPosition(Mathf.RoundToInt(worldPositon.x/cellSize),Mathf.RoundToInt(worldPositon.z/cellSize));
    } 

    public void createGridObjectDebug(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform debugObject = GameObject.Instantiate(debugPrefab, GetGridWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject = debugObject.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridDebugObject(GetGridObject(gridPosition));
               
            }
        }
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }
}
