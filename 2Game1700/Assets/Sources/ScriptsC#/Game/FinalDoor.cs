using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    private int sceneID;

    public void Open()
    {
        if (Inventory.Instance.GetGoldKey()== true)
        {
            sceneID = SceneManager.GetActiveScene().buildIndex;
            sceneID++;
            SceneManager.LoadScene(sceneID);
        }
    }
}
