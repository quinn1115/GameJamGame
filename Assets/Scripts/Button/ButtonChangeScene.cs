using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonChangeScene : ButtonCollider
{
    [SerializeField] private string sceneName;

    protected override void OnClick()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
