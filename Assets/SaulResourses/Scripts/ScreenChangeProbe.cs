using UnityEngine;

public class ScreenChangeProbe : MonoBehaviour
{
    public ScreenManager screenManager; 
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            screenManager.NextScreen();
        }
    }
}
