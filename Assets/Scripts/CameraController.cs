using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private CinemachinePositionComposer positionComposer;
    float targetY;

    private void Start()
    {
        positionComposer = cinemachineCamera.GetComponent<CinemachinePositionComposer>();
        targetY = positionComposer.TargetOffset.y;
    }
    private void Update()
    {
        Vector3 inputMoveVector = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.W))
        {
            inputMoveVector.z += 1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveVector.z += -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveVector.x += -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveVector.x += 1f;
        }

        Vector3 moveDirection = inputMoveVector.z * transform.forward + transform.right * inputMoveVector.x;
        float moveSpeed = 5f;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        Vector3 rotationVector = new Vector3(0, 0, 0);
        float rotationSpeed = 100f;
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y += -1f;
        }

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
        HandleZoom();

      
    }

    private void HandleZoom()
    {
        float scroll = Input.mouseScrollDelta.y;

        if(scroll !=0)
        {
            targetY += scroll * 2f;
            targetY = Mathf.Clamp(targetY, .5f, 2f);
        }
        Vector3 offset = positionComposer.TargetOffset;
        offset.y = Mathf.Lerp(offset.y, targetY, Time.deltaTime * 5f);
        positionComposer.TargetOffset = offset;

    }
}
