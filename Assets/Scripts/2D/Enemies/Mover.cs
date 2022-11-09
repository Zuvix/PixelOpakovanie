using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MovingEnemy
{

    [SerializeField]
    private float speed;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (isGrounded)
        {
            //animator.SetBool("isWallking",true);
            CheckDirectionChangeCondition();
            if (movingRight)
            {
                rigidBody.velocity = new Vector3(speed, rigidBody.velocity.y);
            }
            else
            {
                rigidBody.velocity = new Vector3(-speed, rigidBody.velocity.y);
            }

        }
    }

    public void CheckDirectionChangeCondition()
    {
        if(IsCloseToWall()|| IsCloseToFall())
        {
            Flip();
        }
    }
}
