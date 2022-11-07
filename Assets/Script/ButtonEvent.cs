using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    public void SceneLoader()
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Stage01.ToString());
        SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
    }
    public void SceneLoader2()
    {
        PlayerPrefs.SetString(SAVE_TYPE.SAVE_Scene.ToString(), SCENE_NAME.Lobby.ToString());
        SceneManager.LoadScene(SCENE_NAME.Loading.ToString());
    }
}
