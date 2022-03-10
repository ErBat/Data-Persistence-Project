using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MainMenu : MonoBehaviour
{
    public InputField nameField;

    public void Start()
    {

        nameField.onEndEdit.AddListener(SubmitName); 
    }

    private void SubmitName(string name)
    {
        PersistanceScript.Instance.SetName(name);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity player
    #endif

    }
}
