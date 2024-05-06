using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    public Toggle soundToggle; 
    public Toggle timeToggle; 
    public TMP_InputField timeInputField; 
    public Text timeText; 
    public GameObject displayTime; 
    public SoundManager soundManager; // Reference to the SoundManager script
    public TimeManager timeManager; // Reference to the TimeManager script
    public string sceneToLoad;

    private Coroutine timerCoroutine;

    void Start()
    {
        // Initialize UI elements and values based on PlayerPrefs
        InitializeUI();

        // Add listeners to toggle value change events
        //soundToggle.onValueChanged.AddListener(OnSoundToggleChanged);
        //timeToggle.onValueChanged.AddListener(OnTimeToggleChanged);

        // Add listener to time input field value change event
        //timeInputField.onValueChanged.AddListener(OnTimeInputValueChanged);
    }

    // Method called when the sound toggle value changes
    void OnSoundToggleChanged(bool isSoundEnabled)
    {
        soundManager.SetSoundEnabled(isSoundEnabled);
    }

    // Method called when the time toggle value changes
    void OnTimeToggleChanged(bool isTimeEnabled)
    {
        timeManager.SetTimeEnabled(isTimeEnabled);

        timeInputField.gameObject.SetActive(isTimeEnabled);
        displayTime.SetActive(isTimeEnabled);

        if (isTimeEnabled)
        {
            StartTimer();
        }
        else
        {
            StopTimer();
        }
    }

    // Method to start the timer
    void StartTimer()
    {
        if (timerCoroutine == null)
        {
            float duration = timeManager.GetTimeDuration(timeManager.defaultTime);
            timerCoroutine = StartCoroutine(CountdownTimer(duration));
        }
        else
        {
            Debug.LogWarning("Timer is already running.");
        }
    }

    // Method to stop the timer
    void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    // Coroutine to count down the timer
    IEnumerator CountdownTimer(float duration)
    {
        float timer = duration;

        while (timer > 0)
        {
            // Convert remaining time to minutes and seconds
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);

            // Update the timer text with the formatted time
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        // Timer has reached zero, do something (e.g., end game, trigger event, etc.)
        Debug.Log("Timer has reached zero!");
        SceneManager.LoadScene(sceneToLoad);
    }

    // Method to initialize UI elements and values based on PlayerPrefs
    void InitializeUI()
    {
        /*timeToggle.isOn = timeManager.GetTimeEnabled();
        timeInputField.gameObject.SetActive(timeToggle.isOn);
        displayTime.SetActive(timeToggle.isOn);

        if (timeToggle.isOn)
        {
            StartTimer();
        }*/
    }

    // Method called when the value of the time input field changes
    void OnTimeInputValueChanged(string value)
    {
        float timeValue;
        if (float.TryParse(value, out timeValue))
        {
            timeManager.SetTimeDuration(timeValue);
        }
        else
        {
            Debug.LogWarning("Invalid input for time value.");
        }
    }
}
