using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintSpeed : MonoBehaviour {

    public float speedIncrease = 2f;
    private Vector3 _movement;

    // Use this for initialization
    void Start()
    {
        _movement = GetComponent<PlayerSprintSpeed>()._movement;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            SetSprintState(true);
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            SetSprintState(false);
        }
    }

    void SetSprintState(bool state)
    {
        float speedchange = (state) ? speedIncrease : -speedIncrease;
        _movement.x += speedchange;
        _movement.y += speedchange;
        _movement.z += speedchange;
    }
}
