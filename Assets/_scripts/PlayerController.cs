using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody RB;

    public float WalkAcclerationSpeed; // How fast we speed up
    public float SprintAcclerationSpeed; // How fast we speed up

    private float SetAccelerationSpeed;

    public float MaxWalkSpeed; // Max speed while walking
    public float MaxSprintSpeed; // max speed while sprinting

    private float SetMaxSpeed; //actual private variable that we use to clamp the speed

    public Animator Anim; // Animator

    private Vector3 IP; //Input vector

	// Use this for initialization
	void Start ()
    {
        RB = GetComponent<Rigidbody>();
	}

    public void updateAnim()
    {
        Vector3 localVel = transform.InverseTransformDirection(RB.velocity);

        Anim.SetFloat("ForwardSpeed", localVel.z);
        Anim.SetFloat("RightSpeed", localVel.x);
    }

    public void keyInput()
    {
        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        SetMaxSpeed = (Input.GetButton("Sprint")) ? MaxSprintSpeed : MaxWalkSpeed;
        SetAccelerationSpeed = (Input.GetButton("Sprint")) ? SprintAcclerationSpeed : WalkAcclerationSpeed;
    }

    public void handleMovement()
    {
      
        RB.AddForce(IP * Time.deltaTime * SetAccelerationSpeed);
        
        RB.velocity = new Vector3(Mathf.Clamp(RB.velocity.x, -SetMaxSpeed, SetMaxSpeed),
                                  RB.velocity.y,
                                  Mathf.Clamp(RB.velocity.z, -SetMaxSpeed, SetMaxSpeed));
    }

    // Update is called once per frame
    void Update ()
    {
        keyInput();
        handleMovement();
        updateAnim();
	}


}
