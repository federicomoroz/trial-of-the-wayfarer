using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMain : Character
{
                      private PlayerStats            statsManager;
    [HideInInspector] public  PlayerStats            StatsManager       { get { return statsManager;      } set { statsManager = value;      } }
    
                      private PlayerMovement         movementManager;
    [HideInInspector] public  PlayerMovement         MovementManager    { get { return movementManager;   } set { movementManager   = value; } }

                      private PlayerHealthManager    healthManager;
    [HideInInspector] public  PlayerHealthManager    HealthManager      { get { return healthManager;     } set { healthManager     = value; } }

                      private PlayerStaminaManager   staminaManager;
    [HideInInspector] public  PlayerStaminaManager   StaminaManager     { get { return staminaManager;    } set { staminaManager    = value; } }

                      private PlayerAttackController attackController;
    [HideInInspector] public  PlayerAttackController AttackController   { get { return attackController;  } set { attackController  = value; } }

                      private PlayerCollisions       collisionsManager;
    [HideInInspector] public  PlayerCollisions       CollisionsManager  { get { return collisionsManager; } set { collisionsManager = value; } }

                      private CurrentDirection       currentDir;
    [HideInInspector] public  CurrentDirection       CurrentDir         { get { return currentDir;        } set { currentDir        = value; } }

                      private PlayerFx               fxController;
    [HideInInspector] public  PlayerFx               FxController       { get { return fxController;      } set { fxController = value;      } }
    [SerializeField]  private VectorValue            startingPosition;
    [HideInInspector] public  VectorValue            StartingPosition   { get { return startingPosition;  } set { startingPosition = value;  } }
    [SerializeField]  private PlayerInventory        myInventory;
    [HideInInspector] public  PlayerInventory        MyInventory        { get { return myInventory;       } set { myInventory = value;       } }
    
    void Awake()
    {
        movementManager   = GetComponent<PlayerMovement>();
        statsManager      = GetComponent<PlayerStats>();
        healthManager     = GetComponent<PlayerHealthManager>();
        staminaManager    = GetComponent<PlayerStaminaManager>();
        attackController  = GetComponent<PlayerAttackController>();
        collisionsManager = GetComponent<PlayerCollisions>();
        MyInventory       = GetComponent<PlayerInventory>();
        MyRb              = GetComponent<Rigidbody2D>();
        MyAnimator        = GetComponentInChildren<Animator>();
        currentDir        = GetComponentInChildren<CurrentDirection>();
        FxController      = GetComponent<PlayerFx>();

        
    }

}
