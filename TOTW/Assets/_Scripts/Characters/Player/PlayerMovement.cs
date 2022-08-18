using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
                      private PlayerMain mainScript;                  
                      private bool       canMove       = true;
    [HideInInspector] public  bool       CanMove { get { return canMove; } set { canMove = value; } }
                      private Vector3    dirToMove;


           
    void Start()
    {
        mainScript                           = GetComponent<PlayerMain>();
        InitializePlayer();
    }

    private void FixedUpdate()
    {
        if(mainScript.StatsManager.CurrentState == PlayerState.interact)
        {
            return;
        }
        else
        {
            if (CanMove)
            {
                GetDirToMove();
                UpdateMoveAndAnimation();
            }
        }

    }

    #region Walking
    public void FreezePlayer()
    {
        CanMove = false;      
        dirToMove = Vector3.zero;
        UpdateMoveAndAnimation();
    }

    private void InitializePlayer()
    {
        transform.position                   = mainScript.StartingPosition.initialValue;
        mainScript.StatsManager.CurrentState = PlayerState.walk;
        mainScript.CurrentDir.CurrentDir     = 1;
        CanMove                              = true;
    }

    private void GetDirToMove()
    {
        
            dirToMove   = Vector3.zero;            
            dirToMove.x = Input.GetAxisRaw("Horizontal");
            dirToMove.y = Input.GetAxisRaw("Vertical");

            dirToMove   = dirToMove.normalized;                                           //dirToMove se normaliza para evitar que se sumen los axis de X e Y cuando se mueve en diagonal.

        
    }

    private void UpdateMoveAndAnimation()
    {
  
        if (mainScript.StatsManager.CurrentState == PlayerState.walk || mainScript.StatsManager.CurrentState == PlayerState.idle)
        {
            if (dirToMove != Vector3.zero)
            {
                MoveCharacter(dirToMove, mainScript.StatsManager.PlayerSpeedWalk);   

                //Walk Animation
                mainScript.MyAnimator.SetFloat("moveX", dirToMove.x);
                mainScript.MyAnimator.SetFloat("moveY", dirToMove.y);
                mainScript.MyAnimator.SetBool("isMoving", true);
                

            }
            else
            {
                mainScript.MyAnimator.SetBool("isMoving", false);
                mainScript.MyRb.velocity = Vector2.zero;
                mainScript.StatsManager.ChangeState(PlayerState.idle);
            }
        }   
    }

    private void MoveCharacter(Vector3 dir, float speed)
    {
        mainScript.MyRb.velocity = dir * speed * Time.fixedDeltaTime;
        mainScript.StatsManager.ChangeState(PlayerState.walk);
    }



    
    #endregion


}
