using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Transform meleePoint;

    [SerializeField]
    float speed = 6.0f;
    [SerializeField]
    float jumpSpeed = 8.0f;
    [SerializeField]
    float gravity = 20.0f;

    [SerializeField]
    private float health;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        gameObject.transform.position = new Vector3(0, 5, 0);
    }

    void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    void Attack()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            int LayerMask = 9;

            if (Physics.Raycast(meleePoint.transform.position, meleePoint.transform.forward, out hit, 5f, LayerMask))
            {
                hit.collider.gameObject.GetComponent<PlayerManager>().health -= 0.1f;
                Debug.Log("Hit");
            }
            
        }
        Debug.DrawRay(meleePoint.transform.position, meleePoint.transform.forward * 5f);
    }
}
