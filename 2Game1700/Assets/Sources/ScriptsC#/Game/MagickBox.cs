using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MagickBox : MonoBehaviour
{
    [SerializeField] private bool randomItem;
    [SerializeField] private Item myItem;
    private bool _isOpen;

    private void Start()
    {
        myItem.gameObject.SetActive(false);
        myItem.transform.position = transform.position;
    }

    public void Open()
    {
        if (Inventory.Instance.GetKeyCount() <= 0) return;
        if (_isOpen == true) return;

        _isOpen = true;

        Inventory.Instance.RemoveItem(3);

        if (randomItem)
        {
            int randomID = Random.Range(0, 4);
            myItem.SetType(randomID);
        }

        myItem.transform.position += Vector3.up;
        myItem.gameObject.SetActive(true);

    }
}
