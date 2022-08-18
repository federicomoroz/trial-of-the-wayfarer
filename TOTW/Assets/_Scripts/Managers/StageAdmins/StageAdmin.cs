using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Los StageAdmin son gerentes de cada nivel. Actúan de intermediarios entre los objetos en juego y los managers de jerarquía alta.

public class StageAdmin : MonoBehaviour
{      
                     protected bool      stageComplete     = false;
                     protected bool      gotVictoryKey     = false;
    [SerializeField] protected int       bgMusic_clip;    
    [SerializeField] protected Transform InitialPosition;
    [SerializeField] protected bool      hasKeys           = false;
    [Header("Signal")]
    [SerializeField] protected Signal    needKeyCounter, noKeyCounter;
    

    protected virtual void Start()
    {
        ResetQuests();
        PlayBgMusic();
        if (hasKeys)
        {
            needKeyCounter?.Raise();
        }
        else
        {
            noKeyCounter?.Raise();
        }
    }

    protected virtual void Update()
    {

    }

    protected void PlayBgMusic()
    {
        MusicManager.Instance.PlayMusicClip(bgMusic_clip, true);
    }

    protected void CheckIfStageIsComplete()
    {
        if (stageComplete)
        {
            print("STAGE COMPLETE");
            OnWin();
        }
    }

    protected void ResetQuests()
    {
        stageComplete = false;
        gotVictoryKey = false;
    }

    public void OnKeyGot()
    {
        gotVictoryKey = true;
        print("Player got the KEY");
        if (gotVictoryKey)
        {
            stageComplete = true;
            CheckIfStageIsComplete();
        }
    }


    protected void OnWin()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Win);
    }

    public void OnPlayerDeath()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.Lose);
    }

}
