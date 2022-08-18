using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeMovement : MonoBehaviour
{
                      private Foe       mainScript;
                      private Transform goalPosition;
    [HideInInspector] public  Transform GoalPosition;
                    //  private int       currentWaypoint = 0;
   

    void Start()
    {
        mainScript = GetComponent<Foe>();
        InitializeFoe();
    }

    public void InitializeFoe()
    {
        mainScript.StatsManager.ChangeState(FoeState.idle);
        mainScript.MyAnimator.SetBool("isMoving", false);
        GoalPosition = mainScript.StatsManager.HomePosition;
        BackToHome();
    }

    public void BackToHome()
    {
        GoalPosition.position = mainScript.StatsManager.HomePosition.position;
        if ((this.transform.position != GoalPosition.position))
        {
            if (mainScript.StatsManager.CurrentState == FoeState.idle || mainScript.StatsManager.CurrentState == FoeState.walk)
            {
                WalkTo(mainScript.MyRb, this.transform, GoalPosition, mainScript.StatsManager.MoveSpeed);
            }
        }
        else
        {
            mainScript.StatsManager.ChangeState(FoeState.idle);
            mainScript.MyAnimator.SetBool("isMoving", false);
            //Patrol();
        }
    }


    public void WalkTo(Rigidbody2D myRb, Transform myTransform, Transform goToTransform, float speed)
    {
        if(mainScript.StatsManager.CurrentState != FoeState.dead || mainScript.StatsManager.CurrentState != FoeState.stagger)
        {
            Vector3 newPosition = Vector3.MoveTowards(myTransform.position, goToTransform.position, speed * Time.fixedDeltaTime);        
            ChangeAnimation(newPosition - myTransform.position);
            myRb.MovePosition(newPosition);
            mainScript.MyAnimator.SetBool("isMoving", true);
            mainScript.StatsManager.ChangeState(FoeState.walk);    
        }
    }

    private void SetAnimatorFloat(Vector2 setVector)
    {
        mainScript.MyAnimator.SetFloat("moveX", setVector.x);
        mainScript.MyAnimator.SetFloat("moveY", setVector.y);
    }

    private void ChangeAnimation(Vector3 direction)
    {
        if      (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimatorFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimatorFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimatorFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimatorFloat(Vector2.down);
            }
        }
    }

    
}
