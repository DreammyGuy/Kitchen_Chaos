using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Loader
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene
    }

    public static Scene targetScene;

    public static void Load(Scene targetScene)
    {
        Loader.targetScene = targetScene;

        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(targetScene.ToString());
    }
}
