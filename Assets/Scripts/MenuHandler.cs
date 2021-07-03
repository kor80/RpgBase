using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement; 

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public void NewGame()
    {   SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {   
        MainManager.Instance.LoadData();
        SceneManager.LoadScene(1);   
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
