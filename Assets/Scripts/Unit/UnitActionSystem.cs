using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set; }

    [SerializeField] Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;


    public event EventHandler OnSelectedUnit;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (HandleUnitAction()) return;
           selectedUnit.Move(MousePosition.GetMousePosition());
        }
    }

    private bool HandleUnitAction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, unitLayerMask))
        {
            if(hitInfo.transform.TryGetComponent(out Unit unit))
            {
                setSelectedUnit(unit);
                return true;
            }
        }
        return false;
    }

    private void setSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnSelectedUnit?.Invoke(this, EventArgs.Empty);
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
