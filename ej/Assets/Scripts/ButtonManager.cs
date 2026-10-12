using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;




public class ButtonManager : MonoBehaviour
{
    public GameObject panelSettings;
    public GameObject panelMenu;
    public PostProcessVolume postVolume;
    private DepthOfField depthOfField;



    private void Start(){
        postVolume.profile.TryGetSettings(out depthOfField);
        panelSettings.SetActive(false);
        panelMenu.SetActive(false);
        postVolume = GetComponent<PostProcessVolume>();

       

    }

    public void Play() {
        SceneManager.LoadScene("Main");

    }

    public void Settings() {
        if(panelSettings.activeSelf == false){
            panelSettings.SetActive(true);

        }
        else if(panelSettings.activeSelf == true) {
            panelSettings.SetActive(false);
        }
    }

    public void Exit() {
        Application.Quit();
    } 

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void MenuPanel() {
        if(panelMenu.activeInHierarchy == true) {
            panelMenu.SetActive(false);
            depthOfField.enabled.value = false;
        }

        else if(panelMenu.activeInHierarchy == false) {
            panelMenu.SetActive(true);
            depthOfField.enabled.value = true;
        }

    }

}
