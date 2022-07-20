using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    [SerializeField] TMP_InputField login, password;
    [SerializeField] TMP_Text errorText;

    public static void LoadGameScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
    
    public void Login()
    {
        string name = login.text;
        string pw = password.text;
        if (!Server.instance.CheckUser(name))
        {
            SetErrorMessage("User not found");
            return;
        }
        SaveData saveData; 
        Server.instance.Load(name, out saveData);
        if(saveData != null && pw != saveData.password)
        {
            SetErrorMessage("Incorrect user or password");
            return;
        }
        LoadGameScene();
    }

    public void Register()
    {
        string name = login.text;
        string pw = password.text;
        if (Server.instance.CheckUser(name))
        {
            SetErrorMessage("User already exists");
            return;
        }
        SaveData saveData = new SaveData(name, pw);
        Server.instance.Register(saveData);
        LoadGameScene();
    }
    
    private void SetErrorMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(SetErrorMessageRoutine(message));
    }
    
    IEnumerator SetErrorMessageRoutine(string message)
    {
        errorText.text = message;
        yield return new WaitForSeconds(3);
        errorText.text = "";  
    }
}
