using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    [SerializeField] private float sensitivity = 200;
    [SerializeField] private float minRotationY = 30;
    [SerializeField] private float maxRotationY = 50;
    [Space]
    [SerializeField] private Transform player;

    private float _rotationY;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        _rotationY -= mouseY;
        _rotationY = Mathf.Clamp(_rotationY, -minRotationY, maxRotationY);

        transform.localRotation = Quaternion.Euler(_rotationY, 0, 0);
        player.Rotate(mouseX * Vector3.up);
    }
}
