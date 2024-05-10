using UnityEngine;

public class Pouse : MonoBehaviour
{
    [SerializeField] GameObject PausePonel;
    private bool isPause;
    
    void Start()
    {
        isPause = false;
        Time.timeScale = 1;
        PausePonel.SetActive(isPause);
        


    }

    // Update is called once per frame
    public void Pouses()
    {
        
         isPause = !isPause;

         PausePonel.SetActive(isPause);

         if (isPause == true) Time.timeScale = 0;
         else Time.timeScale = 1;
        
    }
}
