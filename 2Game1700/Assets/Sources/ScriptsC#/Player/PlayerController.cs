using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJump = 2;
    [SerializeField] private float dashForce = 10;
    [SerializeField] private float dashTime = 0.1f;
    [SerializeField] private float dashReloadTime = 1.5f;

    private int _jumpCount;
    private bool _isGround;
    private bool _isDash;
    private bool _isDashReload;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        Jump();
        Dash();
    }

    private void Move()
    {
        if (_isDash) return;

        float inputX = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(inputX * speedMove * Time.deltaTime, _rigidbody.velocity.y);

        _animator.SetBool("Run", inputX != 0);

        SetScaleX(inputX);
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _isDash == false && _isDashReload == false)
        {
            _rigidbody.velocity = new Vector2(dashForce * transform.localScale.x, _rigidbody.velocity.y);
            StartCoroutine(DashTimer());
            StartCoroutine(DashReload());
        }
    }

    private IEnumerator DashTimer()
    {
        _isDash = true;
        yield return new WaitForSeconds(dashTime);
        _isDash = false;
    }

    private IEnumerator DashReload()
    {
        _isDashReload = true;
        yield return new WaitForSeconds(dashReloadTime);
        _isDashReload = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_jumpCount >= maxJump) return;

            _jumpCount++;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
        }

        _animator.SetBool("Jump", _isGround == false);
        _animator.SetBool("DoubleJump", _jumpCount > 1);
    }

    public void SetIsGround(bool ground)
    {
        _isGround = ground;

        if (ground) _jumpCount = 0;
        else _jumpCount = 1;
    }

    private void SetScaleX(float X)
    {
        float tempX = transform.localScale.x;

        if (X > 0) tempX = 1;
        else if(X < 0) tempX = -1;   

        transform.localScale = new Vector2(tempX, transform.localScale.y);
    }
}
