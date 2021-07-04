using UnityEngine;
using UnityEngine.SceneManagement; 

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public void NewGame()
    {   
        MainManager.Instance.level = 1;
        MainManager.Instance.experience = 0;
        MainManager.Instance.name = null;
        MainManager.Instance.playerPosition = Vector3.zero;
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {   
        MainManager.Instance.LoadData();
        SceneManager.LoadScene(1);   
    }

    public void BackToMenu()
    {   SceneManager.LoadScene(0);
    }

    public void SaveGame()
    {   
        MainManager.Instance.experience = UIManager.Instance.destinationValue;
        MainManager.Instance.name = UIManager.Instance.nameText.text;
        MainManager.Instance.playerPosition = FindObjectOfType<Player>().transform.position;
        MainManager.Instance.SaveData();
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
