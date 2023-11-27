using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementScriptLab : MonoBehaviour
{


    public float speed;
    public KeyCode jump;
    public float jumpHeight = 10;

    public CharacterController thisCC;

    public Vector3 velocity;
    public float gravity = -9;

    public Transform feet;
    public float distance = 0.2f;
    public LayerMask groundMask;

    public bool isGrounded;

    public GameObject carrying;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(feet.position, distance, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        thisCC.Move(move * speed * Time.deltaTime);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(isGrounded && Input.GetKeyDown(jump))
        {
            velocity.y += jumpHeight;
        }
        velocity.y += gravity * Time.deltaTime;
        thisCC.Move(velocity*Time.deltaTime);
    }

    public void changeCarry()
    {
        Transform child = this.gameObject.transform.GetChild(3);
        foreach(Transform carryable in child)
        {
            carryable.gameObject.SetActive(false);
        }
        int location = carrying.ToString().IndexOf("(");
        child.transform.Find(carrying.ToString().Substring(0, location-1)).gameObject.SetActive(true);
    }


}
