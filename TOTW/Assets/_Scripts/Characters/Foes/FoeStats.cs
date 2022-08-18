using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FoeState
{
    idle,
    walk,
    attack,
    stagger,
    dead,
}

public class FoeStats : MonoBehaviour
{
                      private Foe         mainScript;
    [SerializeField]  private FoeState    currentState;
    [HideInInspector] public  FoeState    CurrentState { get { return currentState; } set { currentState = value; } }

    [SerializeField]  private float       hpCurrent;
    [HideInInspector] public  float       HpCurrent    { get { return hpCurrent;    } set { hpCurrent    = value; } }

    [SerializeField]  private FloatValue  hpMax;
    [HideInInspector] public  FloatValue  HpMax        { get { return hpMax;        } set { hpMax        = value; } }

    [SerializeField]  private string      foeName;
    [HideInInspector] public  string      FoeName      { get { return foeName;      } set { foeName      = value; } }

    [SerializeField]  private int         baseAttack;
    [HideInInspector] public  int         BaseAttack   { get { return baseAttack;   } set { baseAttack   = value; } }

    [SerializeField]  private float       moveSpeed = 2;
    [HideInInspector] public  float       MoveSpeed    { get { return moveSpeed;    } set { moveSpeed    = value; } }

    [SerializeField]  private Transform   homePosition;
    [HideInInspector] public  Transform   HomePosition { get { return homePosition; } set { homePosition = value; } }

    [SerializeField]  private Transform[] waypoints;
    [HideInInspector] public  Transform[] Waypoints    { get { return waypoints;    } set { waypoints = value;    } }

    [SerializeField]  private Transform   target;
    [HideInInspector] public  Transform   Target       { get { return target;       } set { target = value;       } }


    void Start()
    {
        mainScript = GetComponent<Foe>();
    }
    
    public void ChangeState(FoeState newState)
    {
        if (CurrentState != newState)
        {
            CurrentState = newState;
            print($"Foe State = {CurrentState}.");
        }
    }
}
