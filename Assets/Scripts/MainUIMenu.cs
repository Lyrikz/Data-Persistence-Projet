#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUIMenu : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;

    public void Start()
    {
        DisplayBestScore();
    }

    public void DisplayBestScore()
    {
        BestScoreText.text = $"Best Score {BestScoreManager.Instance.playerName} : {BestScoreManager.Instance.points}";
    }

    public void StartNew()
    {
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

    public void UpdatePlayerName(string playerName)
    {
        PlayerDataManager.Instance.playerName = playerName;
    }
}
