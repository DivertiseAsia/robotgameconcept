using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour {

	public void ChangeToWorldScene()
    {
        print("loading main");
        SceneManager.LoadScene("main");
    }

    public void ChangeToMenuScene()
    {
        print("loading menu");
        SceneManager.LoadScene("customise");
    }
}
