using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class LobbyManager : MonoBehaviour
{
    public enum MenuType
    {
        MenuType_Enchant = 1,
        MenuType_Option = 5,
    }

    public void StartGame()
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Stage01.ToString());
        SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
    }

    private int activeMenu = 0;

    public int ActiveMenu
    {
        set
        {
            if (value < 1 || value > 5)
            {
                activeMenu = 0;
            }
            else
                activeMenu = value;
        }
    }

    [SerializeField]
    private List<GameObject> popupObjList;

    public void OnClickButton(int i)
    {
        if (i == activeMenu)
        {
            LeanTween.moveLocalY(popupObjList[activeMenu], -1600f, 0.5f);
            activeMenu = 0;
        }
        else
        {
            if(activeMenu != 0)
            {
                LeanTween.moveLocalY(popupObjList[activeMenu], -1600f, 0.5f);
            }
            activeMenu = i;
            LeanTween.moveLocalY(popupObjList[activeMenu], 0f, 0.5f);
        }
    }

    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private TextMeshProUGUI sfx_Text;
    [SerializeField]
    private Slider sfx_Slider;
    [SerializeField]
    private TextMeshProUGUI bgm_Text;
    [SerializeField]
    private Slider bgm_Slider;

    private float valueF;

    public void SFX_ValueChange(float value)
    {
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_SFX.ToString(), value);
        ChangeVolume(sfx_Text, sfx_Slider, SAVE_TYPE.SAVE_SFX, value);
    }

    public void BGM_ValueChange(float value)
    {
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_BGM.ToString(), value);
        ChangeVolume(bgm_Text, bgm_Slider, SAVE_TYPE.SAVE_BGM, value);
    }

    void ChangeVolume(TextMeshProUGUI text, Slider slider, SAVE_TYPE type, float newVolume)
    {
        text.text = newVolume.ToString("N2");
        slider.value = newVolume;

        valueF = newVolume * 30f - 30f;
        if (valueF < -29f)
            valueF = -80f;
        audioMixer.SetFloat(type.ToString(), valueF);
    }


}
