using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeHandler : MonoBehaviour
{
    private int _speed;
    private int _distanceToDestroy;
    private Rigidbody _rb;
    private Vector3 _startPos;

    private void OnEnable()
    {
        ChangeValues(ApplyValues.GetSpeed(), ApplyValues.GetDistance());
        _rb = GetComponent<Rigidbody>();
        _startPos = transform.position;
    }

    private void Update()
    {
        if (DistanceÑovered())
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rb.AddForce(Vector3.forward * _speed, ForceMode.Force);
    }

    private void ChangeValues(int speed, int distanceToDestroy)
    {
        _speed = speed;
        _distanceToDestroy = distanceToDestroy;
    }

    private bool DistanceÑovered()
    {
        return transform.position.z > _startPos.z + _distanceToDestroy;
    }
}
