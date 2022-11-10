using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public HeadUpDisplay headUpDisplay;

    public List<SceneAsset> m_SceneAssets = new List<SceneAsset>();

    public int bestGame = int.MaxValue;
    public int movesCounter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SetEditorBuildSettingsScenes();
    }

    public void Restart()
    {
        headUpDisplay.InitializeHeadUpDisplay();
        TowersManager.Instance.InitializeTowers();
    }    

    public void IncreaseMovesCounter()
    {
        movesCounter++;
        headUpDisplay.UpdateMovesCounterText();
    }

    public void Victory()
    {
        if (movesCounter < bestGame)
        {
            bestGame = movesCounter;
            headUpDisplay.Victory(true);
        }
        else
        {
            headUpDisplay.Victory(false);
        }
    }

    public void SetEditorBuildSettingsScenes()
    {
        List<EditorBuildSettingsScene> editorBuildSettingsScenes = new List<EditorBuildSettingsScene>();
        foreach (var sceneAsset in m_SceneAssets)
        {
            string scenePath = AssetDatabase.GetAssetPath(sceneAsset);
            if (!string.IsNullOrEmpty(scenePath))
            {
                editorBuildSettingsScenes.Add(new EditorBuildSettingsScene(scenePath, true));
            }
        }

        EditorBuildSettings.scenes = editorBuildSettingsScenes.ToArray();
    }
}
