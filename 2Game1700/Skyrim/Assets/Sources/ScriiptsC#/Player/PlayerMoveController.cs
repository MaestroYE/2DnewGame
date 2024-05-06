using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float speedWalk;
    [SerializeField] private float speedRun;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravityForce;
    [SerializeField] private PlayerAnimationController animationController;

    private float _gravity;
    private CharacterController _characterController;

    public float InputX { get; private set; }
    public float InputZ { get; private set; }

    public static PlayerMoveController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 direction = (transform.forward * InputZ + transform.right * InputX) * GetSpeed() * Time.deltaTime;
        direction.y = GetGravity();
        _characterController.Move(direction);
    }

    private float GetSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift)) return speedRun;
        else return speedWalk;
    }

    private float GetGravity()
    {
        if (_characterController.isGrounded == false) _gravity -= gravityForce * Time.deltaTime;
        return _gravity;
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded) _gravity = jumpForce;
    }

    public CharacterController GetCharacterController()
    {
        return _characterController;
    }

    public bool GetIsGround()
    {
        return _characterController.isGrounded;
    }
}
