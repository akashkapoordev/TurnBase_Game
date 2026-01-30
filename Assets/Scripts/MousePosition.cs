using UnityEngine;

public class MousePosition : MonoBehaviour
{
    public static MousePosition Instance;

    [SerializeField] private LayerMask mousePlaneLayerMask;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        transform.position = GetMousePosition();
        
    }


    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, Instance.mousePlaneLayerMask))
        {
            return hitInfo.point;
        }
        return Vector3.zero;
    }
}
