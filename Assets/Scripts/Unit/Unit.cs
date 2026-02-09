using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] Animator unitAnimator;
    private Vector3 targetPosition;
    private GridPosition gridPosition;

    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition,this);
    }

    private void Update()
    { 
        float stoppingDistance = .1f;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if(distance > stoppingDistance)
        {
            Vector3 aimDirection = (targetPosition - transform.position).normalized;

            float speed = 4f;
            transform.position += aimDirection * speed * Time.deltaTime;
            float roatationSpeed = 15f;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * roatationSpeed);
            unitAnimator.SetBool("IsWalking", true);
        }
        else
        {
            unitAnimator.SetBool("IsWalking", false);

        }

        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newGridPosition != gridPosition)
        {
            LevelGrid.Instance.UnitMoveGridPosition(this, gridPosition, newGridPosition);
            gridPosition = newGridPosition;
        }

    }

    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
