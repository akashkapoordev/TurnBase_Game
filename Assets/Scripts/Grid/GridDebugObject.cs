using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{
    private GridObject gridObject;
    [SerializeField] private TextMeshPro text;
    public void SetGridDebugObject(GridObject gridObject)
    {
        this.gridObject = gridObject;
    }


    private void Update()
    {
        text.text = gridObject.ToString();
    }

}
