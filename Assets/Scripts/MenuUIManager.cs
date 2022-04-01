using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public InputField PlayerInputField;
    public TextMeshProUGUI HighScore;
    private void Start()
    {
        HighScore.text = $"HighScore: {MenuManager.Instance.HighScoreName} : {MenuManager.Instance.HighScore}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        MenuManager.Instance.PlayerName = PlayerInputField.text;
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
