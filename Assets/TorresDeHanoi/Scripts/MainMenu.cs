using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text bestGameText;

    private void Awake()
    {
        if (GameManager.Instance == null) return;
        if (GameManager.Instance.bestGame == int.MaxValue) return;

        bestGameText.text = GameManager.Instance.bestGame.ToString();
    }
    
    public void Play()
    {
        SceneManager.LoadScene("Assets/TorresDeHanoi/Scene/02_Game.unity");
    }

    public void Exit()
    {
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
         #else
            Application.Quit();
         #endif
    }
}
