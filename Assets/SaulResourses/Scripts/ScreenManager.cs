using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject[] screens; 
    private int currentScreenIndex = 0;


    private void Start()
    {
        for (int i = 1; i < screens.Length; i++) 
        { 
            screens[i].SetActive(false);
        }

    }
    public void NextScreen()
    {

        screens[currentScreenIndex].SetActive(false);
        currentScreenIndex++;

        if (currentScreenIndex < screens.Length)
        {
            screens[currentScreenIndex].SetActive(true);
        }
    }

}
