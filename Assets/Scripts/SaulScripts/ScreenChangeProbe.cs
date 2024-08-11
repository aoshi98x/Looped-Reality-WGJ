using UnityEngine;

public class ScreenChangeProbe : MonoBehaviour
{
    [SerializeField] ScreenManager screenManager; 
    private void Start() {
        screenManager = FindAnyObjectByType<ScreenManager>();
    }
    void Update()
    {

        if (Input.GetAxis("Horizontal") != 0 && screenManager.screens[0].activeInHierarchy || Input.GetAxis("Vertical") != 0 && screenManager.screens[0].activeInHierarchy)
        {
            screenManager.NextScreen();
        }
        else if(Input.GetButtonDown("Fire2") && screenManager.screens[1].activeInHierarchy)
        {
            screenManager.NextScreen();
        }
        else if(Input.GetButtonDown("Light") && screenManager.screens[2].activeInHierarchy)
        {
            screenManager.NextScreen();
        }
        else if(Input.GetButtonDown("ActionPlayer") && screenManager.screens[3].activeInHierarchy)
        {
            screenManager.NextScreen();
        }
        else if(Input.GetButtonDown("Fire1") && screenManager.screens[4].activeInHierarchy)
        {
            screenManager.NextScreen();
            screenManager.gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
