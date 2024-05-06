using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private string _nameRunAnimation = "Run";
    private string _nameJumpAnimation = "Jump";
    private string _nameMeleeAttacAnimation = "Attack";
    private string _nameReloadAnimation = "Reload";

    private Animator _animator;
    public static PlayerAnimationController Instance;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Attack();
    }

    private void Move()
    {
        var input = PlayerMoveController.Instance;
        _animator.SetBool(_nameRunAnimation, input.InputX != 0 || input.InputZ != 0);
    }

    private void Jump()
    {
        var input = PlayerMoveController.Instance;
        _animator.SetBool(_nameJumpAnimation, input.GetIsGround() == false);
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0)) _animator.SetBool(_nameMeleeAttacAnimation, true);
    }
}
