using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum Scenes
{
    MainMenu=0,
    GameMenu=1,
    Scene1=2,
    Scene2=3
}

public class BecureSceneManager : MonoBehaviour
{
    public Scenes Scene;

    public void LoadScene()
    {
        SceneManager.LoadScene((int)Scene);

    }
}
