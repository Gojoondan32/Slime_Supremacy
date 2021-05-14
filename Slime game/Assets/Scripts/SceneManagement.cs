using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeScene(string scene)
    {
        //Change scenes depending on the string value
        switch (scene)
        {
            case "Tutorial":
                SceneManager.LoadScene("Tutorial");
                break;
            case "Main Menu":
                SceneManager.LoadScene("Main Menu");
                break;
            case "Quit":
                Application.Quit();
                break;
            case "Options":
                SceneManager.LoadScene("Options");
                break;
        }
    }
}
