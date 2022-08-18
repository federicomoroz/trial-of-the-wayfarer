using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : Character
{     
                      private SpriteRenderer  mySr;
    [HideInInspector] public  SpriteRenderer  MySr              { get { return mySr;              } set { mySr              = value;  } }

                      private FoeCollisions   collisionsManager;
    [HideInInspector] public  FoeCollisions   CollisionsManager { get { return collisionsManager; } set { collisionsManager = value;  } }

                      private FoeHealth       healthManager;
    [HideInInspector] public  FoeHealth       HealthManager     { get { return healthManager;     } set { healthManager     = value;  } }

                      private FoeMovement     movementManager;
    [HideInInspector] public  FoeMovement     MovementManager   { get { return movementManager;   } set { movementManager   = value;  } }

                      private FoeAttack       attackController;
    [HideInInspector] public  FoeAttack       AttackController  { get { return attackController;  } set { attackController  = value;  } }

                      private FoeStats        statsManager;
    [HideInInspector] public  FoeStats        StatsManager      { get { return statsManager;      } set { statsManager      = value;  } }

    [SerializeField]  private GameObject      myHealthBar;

                      private FoeFx           myFx;
    [HideInInspector] public  FoeFx           MyFx              { get { return myFx;              } set { myFx              = value;   } }



    

    


    private void Awake()
    {
        collisionsManager = GetComponent<FoeCollisions>();
        healthManager     = GetComponent<FoeHealth>();
        movementManager   = GetComponent<FoeMovement>();
        attackController  = GetComponent<FoeAttack>();
        statsManager      = GetComponent<FoeStats>();
        MyRb              = GetComponent<Rigidbody2D>();
        MySr              = GetComponentInChildren<SpriteRenderer>();
        MyAnimator        = GetComponentInChildren<Animator>();
        MyFx              = GetComponent<FoeFx>();  
    }

    private void Start()
    {
        StatsManager.Target = GameObject.FindWithTag("Player").transform;
        StatsManager.ChangeState(FoeState.idle);       
    }


    public void FreezeCharacter()
    {
        print("Foes frozen");
        MovementManager.enabled = false;
        AttackController.enabled = false;
    }

    public void HealthBarOn()
    {
        if(myHealthBar.activeSelf != true)
        {
            myHealthBar.SetActive(true);
        }

        myHealthBar.GetComponent<healthBar_Foe>().ShowHpBar();
    }





}  



