using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    [SerializeField] private Animator anim;

    string targetScene;
    bool isLoading = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        SceneManager.sceneLoaded += TransitionOut;
    }

    public void LoadScene(string a_targetScene)
    {
        if(!isLoading)
        {
            targetScene = a_targetScene;
            anim.SetTrigger("TransitionIn");
            isLoading = true;
        }
    }

    /// <summary>
    /// Used by animation event
    /// </summary>
    private void Load()
    {
        SceneManager.LoadSceneAsync(targetScene);
        isLoading = false;
    }

    private void TransitionOut(Scene scene, LoadSceneMode loadSceneMode)
    {
        anim.SetTrigger("TransitionOut");
    }
}
