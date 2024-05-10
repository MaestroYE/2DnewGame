using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class WallCheker : MonoBehaviour
{
    private PlayerController _playerController;
    private string _tagWall = "Wall";

    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == _tagWall)
        {
            _playerController.SetIsWall(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _tagWall)
        {
            _playerController.SetIsWall(false);
        }
    }
}
