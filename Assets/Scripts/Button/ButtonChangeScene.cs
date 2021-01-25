using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonChangeScene : ButtonCollider
{
    [SerializeField] private string sceneName;
    [SerializeField] private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    protected override void OnClick()
    {
        anim.SetTrigger("TransitionOn");
    }

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
