using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    interact,
    attack,
    hurt,
    dead,
}
public class PlayerStats : MonoBehaviour
{
                      private PlayerMain  mainScript;

                      private PlayerState currentState;
    [HideInInspector] public  PlayerState CurrentState         { get { return currentState;         } set { currentState         = value; } }

    [SerializeField]  private FloatValue  playerHp;
    [HideInInspector] public  FloatValue  PlayerHp             { get { return playerHp;             } set { playerHp             = value; } }

    [SerializeField]  private FloatValue  playerStamina;
    [HideInInspector] public  FloatValue  PlayerStamina        { get { return playerStamina;        } set { playerStamina        = value; } }

    [SerializeField]  private int         playerSpeedWalk  = 5;
    [HideInInspector] public  int         PlayerSpeedWalk      { get { return playerSpeedWalk;      } set { playerSpeedWalk      = value; } }




    void Start()
    {
        mainScript = GetComponent<PlayerMain>();               
    }

    public void ChangeState(PlayerState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
        }
    }



}
