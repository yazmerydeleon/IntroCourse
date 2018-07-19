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

    public float RotateSpeed;

    public Animator Anim; // Animator

    private Vector3 IP; //Input vector

    private Camera cam;

    public GunController Gun;
    public HealthController Health;

    // Use this for initialization
    void Start ()
    {
        //GunController = GetComponent<GunController>();

        RB = GetComponent<Rigidbody>();
        cam = GameObject.FindObjectOfType<Camera>();
        if (cam == null)
        {
            Debug.Log("NO CAMERA");
        }
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

        if (Input.GetMouseButton(0))
        {
            Gun.Fire();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Health.TakeDamage(10);
        }
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
        if (Physics.Raycast(ray, out hit, 10000))
        {
            Vector3 forward = (transform.position - hit.point).normalized * -1;
            transform.forward = Vector3.MoveTowards(transform.forward, forward, RotateSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }

    // Update is called once per frame
    void Update ()
    {
        keyInput();
    }

    private void FixedUpdate()
    {
        handleMovement();
        updateAnim();
        doMouseLook();
    }
}
