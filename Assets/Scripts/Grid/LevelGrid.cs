using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    public static LevelGrid Instance { get; private set; }

    [SerializeField] Transform debugObjectPrefab;
    private GridSystem GridSystem;


    private void Awake()
    {
        Instance = this;
        GridSystem = new GridSystem(20, 20, 2f);
        GridSystem.createGridObjectDebug(debugObjectPrefab);
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = GridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnitList();
    }

    public void RemoveUnitListAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return GridSystem.GetGridPosition(worldPosition);
    }

    public void UnitMoveGridPosition(Unit unit,GridPosition fromGridPositon,GridPosition toGridPosition)
    {
        RemoveUnitListAtGridPosition(fromGridPositon,unit);
        AddUnitAtGridPosition(toGridPosition, unit);
    }

}
