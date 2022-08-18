using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static       GameManager       Instance;
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;       

    public GameState State { get; private set; }

    public List<ScriptableObject> persistentObjects = new List<ScriptableObject>();


    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else { Destroy(gameObject); }        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        ChangeState(GameState.Starting);
        
    }

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                break;
            case GameState.SpawnPlayer:
                break;
            case GameState.Playing:
                break;
            case GameState.Pause:
                break;
            case GameState.Lose:
                HandleLose();
                break;
            case GameState.Win:
                HandleWin();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);

        print($"New GAME state: {newState}");
    }

    private void HandleStarting()
    {
        ChangeState(GameState.SpawnPlayer);
    }

    private void HandleSpawnPlayer()
    {
        ChangeState(GameState.Playing);
    }

    private void HandlePlaying()
    {

    }

    private void HandlePause()
    {

    }

    private void HandleLose()
    {
        SceneController.Instance.SwitchToSceneHandler("GameOver");
        ResetPersistentObjectsValue();

     
    }    
    private void HandleWin()
    {
        SceneController.Instance.SwitchToSceneHandler("Win");
        ResetPersistentObjectsValue();
    }

    private void ResetPersistentObjectsValue()
    {
        foreach (ScriptableObject item in persistentObjects)
        {
            if (item is BoolValue bv) bv.ResetValue();
            else if (item is FloatValue fv) fv.ResetValue();
            else if (item is Inventory iv) iv.ResetValue();
        }
    }

    public enum GameState
    {
        Starting,
        SpawnPlayer,
        Playing,
        Pause,
        Win,
        Lose,
    }
}
