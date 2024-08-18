using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private Animator animator;

    public Timer timer;
    public bool inBattle;
    public Canvas canvas;
    public Healthbar healthbar;

    void Start()
    {
        animator= GetComponent<Animator>();
        canvas.GetComponent<Canvas>().enabled = false; //Should only enable after two seconds - message saying 'Get Ready!' enables during this time
    }
    void Update()
    {
        if (inBattle)
        {
            canvas.GetComponent<Canvas>().enabled = true;
            animator.SetBool("IsRunning", false);
            return; //Establishes a barrier - loops the script from this point

        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
        if (direction != Vector3.zero)
        {
            animator.SetBool("IsRunning", true);
        }

        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            timer.StartCoroutine(timer.StartBattle());
            inBattle = true;
        }
    }
}
