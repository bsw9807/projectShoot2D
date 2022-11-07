using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum SAVE_TYPE
{
    SAVE_Name,
    SAVE_Level,
    SAVE_EXP,
    SAVE_Scene,
    SAVE_SFX,
    SAVE_BGM,
    SAVE_Skill001,
    SAVE_Skill002,
    SAVE_Skill003,
    SAVE_Skill004,
    SAVE_Skill005,
    SAVE_Skill006,

}

public enum SCENE_NAME
{
    Stage01,
    Lobby,
    Loading,
}

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputField;

    private bool haveUserInfo;

    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        InitLoginScene();
    }
    private void InitLoginScene()
    {
        if (PlayerPrefs.GetString(SAVE_TYPE.SAVE_Name.ToString()).Length < 2)
        {
            text.gameObject.SetActive(false);
            inputField.gameObject.SetActive(true);
            haveUserInfo = false;
        }
        else
        {
            text.text = "WELCOME, " + PlayerPrefs.GetString(SAVE_TYPE.SAVE_Name.ToString());
            text.gameObject.SetActive(true);
            haveUserInfo = true;
        }   
    }

    private void CreateUserData(string userName)
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Name.ToString(), inputField.text);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Level.ToString(), 1);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_EXP.ToString(), 0);
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_BGM.ToString(), 1f);
        PlayerPrefs.SetFloat(SAVE_TYPE.SAVE_SFX.ToString(), 1f);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill001.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill002.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill003.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill004.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill005.ToString(), 0);
        PlayerPrefs.SetInt(SAVE_TYPE.SAVE_Skill006.ToString(), 0);
    }

    public void LoginButton()
    {
        if (!haveUserInfo)
        {
            if (inputField.text.Length > 2)
            {
                CreateUserData(inputField.text);
                haveUserInfo = true;
            }
            else
                Debug.Log("입력한 아이디가 짧습니다");
        }
        if (haveUserInfo)
        {
            PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Lobby.ToString());
            SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
        }
    }

    public void InitUserData()
    {
        PlayerPrefs.DeleteAll();
        InitLoginScene();
    }
}
