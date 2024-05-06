using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private Transform point;
    [SerializeField] private Vector3 startPoint;

    private bool _isRight;

    private void Start()
    {
        startPoint = transform.position;
    }

    private void FixedUpdate()
    {
        if (_isRight) MoveToPoint(point.position);
        else MoveToPoint(startPoint);
    }


    private void MoveToPoint(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speedMove * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target) < 1)
            _isRight = !_isRight;
    }

}
