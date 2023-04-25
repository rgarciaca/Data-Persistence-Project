using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField playerNameField;
    public Button startButton;

    public void TextChanged()
    {
        startButton.gameObject.SetActive(true);
    }

    private void Start()
    {
        startButton.gameObject.SetActive(false);
        if (GameManager.Instance.bestScoreExists)
        {
            bestScoreText.gameObject.SetActive(GameManager.Instance.bestScoreExists);
        }
    }

    public void StartNew()
    {
        GameManager.Instance.playerName = playerNameField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
