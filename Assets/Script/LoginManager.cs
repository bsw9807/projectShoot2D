using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum SAVE_TYPE
{
    SAVE_Name,
    SAVE_Scene,

}

public enum SCENE_NAME
{
    Stage01,
    Lobby,
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
}
