using UnityEngine;

public class ScreenChangeProbe : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager; 
    private void Start() {
        screenManager = FindAnyObjectByType<ScreenManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            screenManager.NextScreen();
        }
    }
}
