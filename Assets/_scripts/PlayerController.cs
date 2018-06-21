using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    GunController playerGun;

    private Rigidbody RB;
    private Vector3 IP;
    private Camera cam;

    public float SprintAccelerationSpeed;
    public float WalkAccelerationSpeed;
    public float MaxWalkSpeed;
    public float MaxSprintSpeed;
    public float RotateSpeed;

    private float SetMaxSpeed;
    private float SetAccelerationSpeed;

    public Animator Anim;

    public GunController gun;

    float test;

	// Use this for initialization
	void Start () {

        RB = GetComponent<Rigidbody>();
        cam = GameObject.FindObjectOfType<Camera>();
        if(cam == null)
        {
            Debug.Log("NO CAMERA");
        }
	}

    public void updateAnim()
    {
        Vector3 localVel = transform.InverseTransformDirection(RB.velocity);

        Anim.SetFloat("ForwardSpeed",localVel.z);
        Anim.SetFloat("RightSpeed", localVel.x);
    }

    public void keyInput()
    {
        IP.x = Input.GetAxisRaw("Horizontal");
        IP.z = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
        {
            gun.Fire();
        }

        SetMaxSpeed = (Input.GetButton("Sprint")) ? MaxSprintSpeed : MaxWalkSpeed;
        SetAccelerationSpeed = (Input.GetButton("Sprint")) ? SprintAccelerationSpeed : WalkAccelerationSpeed;

    }

    public void handleMovement()
    {

        RB.AddForce(IP * Time.deltaTime * SetAccelerationSpeed);

        RB.velocity = new Vector3(Mathf.Clamp(RB.velocity.x, -SetMaxSpeed, SetMaxSpeed),
                                  RB.velocity.y,
                                  Mathf.Clamp(RB.velocity.z, -SetMaxSpeed, SetMaxSpeed));

    }

    public void doMouseLook()
    {
        RaycastHit hit;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 10000))
        {
            Vector3 forward = (transform.position - hit.point).normalized * -1;

            transform.forward = Vector3.MoveTowards(transform.forward, forward, RotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0,transform.eulerAngles.y,0);
            //Debug.Log(hit.point);
        }
        
    }

    // Update is called once per frame
    void Update () {

        keyInput();
        handleMovement();
        updateAnim();
        doMouseLook();
       
        //Debug.Log(test);
	}


}
