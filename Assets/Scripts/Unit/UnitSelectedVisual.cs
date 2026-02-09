using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] Unit unit;
    [SerializeField] MeshRenderer selectedUnitMeshRenderer;

    private void Start()
    {
        HideVisual();
        UnitActionSystem.Instance.OnSelectedUnit += Instance_OnSelectedUnit;
    }

    private void Instance_OnSelectedUnit(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
        {
            ShowVisual();
        }
        else
        {
            HideVisual();
        }
    }

    private void HideVisual()
    {
        selectedUnitMeshRenderer.enabled = false;
    }
    private void ShowVisual()
    {
        selectedUnitMeshRenderer.enabled = true;
    }
}
