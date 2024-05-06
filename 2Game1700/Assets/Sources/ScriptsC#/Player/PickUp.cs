using UnityEngine;


public class PickUp : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            Inventory.Instance.AddItem((int)item.MyType);
            Destroy(item.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out MagickBox magickBox))
        {
            magickBox.Open();
        }

        if (collision.gameObject.TryGetComponent(out FinalDoor finalDoor))
        {
            finalDoor.Open();
        }
    }
}
