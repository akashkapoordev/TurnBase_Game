using UnityEngine;

public class Unit : MonoBehaviour
{
    private Vector3 targetPosition;


    private void Update()
    {
        float stoppingDistance = .1f;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if(distance > stoppingDistance)
        {
            Vector3 aimDirection = (targetPosition - transform.position).normalized;

           // Debug.Log(aimDirection);
            float speed = 4f;
            transform.position += aimDirection * speed * Time.deltaTime;
        }
    

        if(Input.GetMouseButtonDown(0))
        {
            Move(MousePosition.GetMousePosition());
        }
    }

    private void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }
}
