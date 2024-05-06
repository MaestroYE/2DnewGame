using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GroundCheker : MonoBehaviour
{
    private PlayerController _playerController;
    private string _tagGround = "Ground";

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == _tagGround)
        {
            _playerController.SetIsGround(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _tagGround)
        {
            _playerController.SetIsGround(false);
        }
    }
}
