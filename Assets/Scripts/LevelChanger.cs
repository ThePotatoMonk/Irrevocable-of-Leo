using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;
    private string sceneToGo;

    // Update is called once per frame
    void Update()
    {

    }

    // Triggers fade out animation
    public void FadeToLevel(string name)
    {
        sceneToGo = name;
        animator.SetTrigger("FadeOut");
        OnFadeComplete();
    }

    // Loads next scene
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToGo);
    }

}
