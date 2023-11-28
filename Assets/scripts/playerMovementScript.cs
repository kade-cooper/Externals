using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class playerMovementScript : MonoBehaviour
{


    public float speed;
    public KeyCode jump;
    public float jumpHeight = 10;

    public CharacterController thisCC;

    public Vector3 velocity;
    public Vector3 lastVelocity;
    public float acceleration;
    public float force;
    public float gravity = -30;

    public Transform feet;
    public float distance = 0.2f;
    public LayerMask groundMask;

    public bool isGrounded;

    public int count=0;


    // Start is called before the first frame update
    void Start()
    {
        //gravity = -30;
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

        acceleration = (this.GetComponent<CharacterController>().velocity.magnitude - lastVelocity.magnitude) / Time.fixedDeltaTime;
        lastVelocity = this.GetComponent<CharacterController>().velocity;
        force = System.Math.Abs(acceleration * gravity);
        //var writer = null;
        if (File.Exists("forceFile"))
        {
            //var writer = File.CreateText("forceFile");
        }
        else
        {
            var writer = File.CreateText("forceFile");
            Debug.Log("created file");
        }

        if (force > 2000 && File.Exists("forceFile"))
        {
            /*
            using (var fs = File.Open("forceFile", FileMode.Open, FileAccess.Write, FileShare.None))
            {
                Debug.Log("opened file");
                Byte[] info = new UTF8Encoding(true).GetBytes(force.ToString());
                fs.Write(info);
            }
            */
            using (StreamWriter sw = File.AppendText("forceFile"))
            {
                Debug.Log("opened file");
                sw.WriteLine(force + "," + gravity);
                sw.Close();
            }
            count += 1;
            //fs.Close();
        }

    }


}
