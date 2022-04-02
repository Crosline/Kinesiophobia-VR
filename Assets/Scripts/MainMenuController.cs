using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject menuPanel;
    public GameObject startPanel;
    public GameObject settingsPanel;
    public GameObject adminPanel;

    public Slider audioSlider;

    public AudioMixer audioMixer;
    public float masterVolume;

    public AudioSource buttonSound;

    void Awake() {
        masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0);
        settingsPanel.SetActive(true);
        audioSlider.value = masterVolume;
        SetMasterVolume(masterVolume);
        settingsPanel.SetActive(false);

    }
    public void OpenStart(bool isOpen) {
        startPanel.SetActive(isOpen);
        menuPanel.SetActive(!isOpen);
    }

    public void StartGame360()
    {
        SceneManager.LoadScene("360Video");
    }
    public void StartGameFlat()
    {
        SceneManager.LoadScene("FlatVideo");
    }
    public void OpenSettings(bool isOpen) {
        settingsPanel.SetActive(isOpen);
        menuPanel.SetActive(!isOpen);
    }

    public void OpenAdminPanel(bool isOpen) {
        adminPanel.SetActive(isOpen);
        menuPanel.SetActive(!isOpen);
    }

    public void SetMasterVolume(float volume) {
        masterVolume = volume;
        audioMixer.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
    }

    public void ButtonOnClickSound() {
        buttonSound.Play();
    }
    public void ExitGame() {
        Application.Quit();
    }
}
