using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum SAVE_TYPE
{
    SAVE_Name,
    SAVE_Scene,

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

    private void Awake()
    {
        if (PlayerPrefs.GetString(SAVE_TYPE.SAVE_Name.ToString()).Length < 2)
        {
            inputField.gameObject.SetActive(true);
            haveUserInfo = false;
        }
        else
            haveUserInfo = true;
    }

    public void LoginButton()
    {
        if (!haveUserInfo)
        {
            if (inputField.text.Length > 2)
            {
                PlayerPrefs.SetString(SAVE_TYPE.SAVE_Name.ToString(), inputField.text);
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
}
