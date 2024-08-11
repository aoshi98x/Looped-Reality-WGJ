using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.UI;
using Unity.VisualScripting;

public class MenuController : MonoBehaviour
{
    //Gameplay Settings
    [SerializeField] private TMP_Text ControllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControllerSen = 4;

    //Toggle Settings
    [SerializeField] private Toggle invertYToggle = null;

    //Graphics Settings
    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTextValue = null;
    [SerializeField] private float defaultBrightness = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown qualityDropdown;
    [SerializeField] private Toggle fullScreenToggle;

    private int quialitylevel;
    private bool isFullScreen;
    private float brightnessLevel;

    //Volume Setting
    [SerializeField] private TMP_Text volumenTextValue = null;
    private float maxSliderAmount = 100.0f;
    [SerializeField] private Slider volumenSlider = null;
    [SerializeField] private float defaultVolume = 1.0f;

    //Confirmation
    //[SerializeField] private GameObject comfirmationPrompt = null;

    //Levels to load
    public string newGameLevel;
    private string levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    //Resolution Dropdowns
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    //Resolution Dropdowns
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;                
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //levels to load
    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("Savedlevel");
            SceneManager.LoadScene(levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ResumeGameDialog()
    {
        if (PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("Savedlevel");
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    //Volume Settings
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume * maxSliderAmount;
        volumenTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        //StartCoroutine(ConfirmationBox());
    }

    public void ResetButton(string menuType)
    {
        if(menuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumenSlider.value = defaultVolume;
            volumenTextValue.text = defaultVolume.ToString("100");
            VolumeApply();
        }

        if(menuType == "Gameplay")
        {
            ControllerSenTextValue.text = defaultSen.ToString("0");
            controllerSenSlider.value = defaultSen;
            mainControllerSen = defaultSen;
            invertYToggle.isOn = false;
            GameplayApply();
        }

        if (menuType == "Graphics")
        {
            //Reset brightness value
            brightnessSlider.value = defaultBrightness;
            brightnessTextValue.text= defaultBrightness.ToString("0.0");

            qualityDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);

            fullScreenToggle.isOn = false;
            Screen.fullScreen = false;

            Resolution currentResolution = Screen.currentResolution;
            Screen.SetResolution(currentResolution.width, currentResolution.height, Screen.fullScreen);
            resolutionDropdown.value = resolutions.Length;
            GraphicsApply();
        }
    }

    //Gameplay Settings
    public void  SetControllerSen(float sensitivity)
    {
        mainControllerSen = Mathf.RoundToInt(sensitivity);
        ControllerSenTextValue.text = sensitivity.ToString("0");
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSen", mainControllerSen);
        //StartCoroutine(ConfirmationBox());
    }

    //Graphics Settings
    public void SetBrightness(float brightness)
    {
        brightnessLevel = brightness;
        brightnessTextValue.text = brightness.ToString("0.0");
    }

    public void SetFullScreen(bool isFullscreen)
    {
        isFullScreen = isFullscreen;        
    }

    public void SetQuality(int qualityIndex)
    {
        quialitylevel = qualityIndex;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessLevel);

        PlayerPrefs.SetInt("masterQuality", quialitylevel);
        QualitySettings.SetQualityLevel(quialitylevel);

        PlayerPrefs.SetInt("masterFullscreen", (isFullScreen ? 1 : 0));
        Screen.fullScreen = isFullScreen;

        //StartCoroutine(ConfirmationBox());
    }

    //Confirmation
    /*public IEnumerator ConfirmationBox()
    {
        comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        comfirmationPrompt.SetActive(false);
    }*/
}
