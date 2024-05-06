using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int swordCount;
    [SerializeField] private int shieldCount;
    [SerializeField] private int coinCount;
    [SerializeField] private int keyCount;
    [SerializeField] private bool goldKey;
    [Space]
    [SerializeField] private GameObject swordObject;
    [SerializeField] private GameObject shieldObject;

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    public void AddItem(int itemID)
    {
        if (itemID == 0) swordCount++;
        if (itemID == 1) shieldCount++;
        if (itemID == 2) coinCount++;
        if (itemID == 3) keyCount++;
        if (itemID == 4) goldKey = true;

        RefreshUI();
    }

    public void RemoveItem(int itemID)
    {
        if (itemID == 0) swordCount--;
        if (itemID == 1) shieldCount--;
        if (itemID == 2) coinCount--;
        if (itemID == 3) keyCount--;
        if (itemID == 4) goldKey = false;

        RefreshUI();
    }

    private void RefreshUI()
    {
        swordObject.SetActive(swordCount > 0);
        shieldObject.SetActive(shieldCount > 0);
    }

    public int GetSwordCount() => swordCount;
    public int GetShieldCount() => shieldCount;
    public int GetCoinCount() => coinCount;
    public int GetKeyCount() => keyCount;
    public bool GetGoldKey() => goldKey;
}
