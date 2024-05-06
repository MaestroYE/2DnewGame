using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Item : MonoBehaviour
{
    [SerializeField] private Sprite swordSprite;
    [SerializeField] private Sprite shieldSprite;
    [SerializeField] private Sprite coinSprite;
    [SerializeField] private Sprite keySprite;
    [SerializeField] private Sprite goldKeySprite;
    public enum TypeItem
    {
        Sword = 0,
        Shield = 1,
        Coin = 2,
        Key = 3,
        GoldKey = 4
    }
    public TypeItem MyType;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        LoadSprite();
    }

    public void SetType(int typeID)
    {
        if (typeID == 0) MyType = TypeItem.Sword;
        else if (typeID == 1) MyType = TypeItem.Shield;
        else if (typeID == 2) MyType = TypeItem.Coin;
        else if (typeID == 3) MyType = TypeItem.Key;
        else if (typeID == 4) MyType = TypeItem.GoldKey;

        LoadSprite();
    }

    private void LoadSprite()
    {
        if (MyType == TypeItem.Sword) SetSprite(swordSprite);
        else if (MyType == TypeItem.Shield) SetSprite(shieldSprite);
        else if (MyType == TypeItem.Coin) SetSprite(coinSprite);
        else if (MyType == TypeItem.Key) SetSprite(keySprite);
        else if (MyType == TypeItem.GoldKey) SetSprite(goldKeySprite);
    }

    private void SetSprite(Sprite newSprite)
    {
        _spriteRenderer.sprite = newSprite;
    }
}
