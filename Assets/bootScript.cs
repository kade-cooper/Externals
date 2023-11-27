using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bootScript : MonoBehaviour
{
    public KeyCode interact;
    public GameObject thisCarryable;
    public GameObject visuals;
    private bool playerIn = false;
    public playerMovementScriptLab pmsl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact) && pmsl.carrying == null && playerIn == true)
        {
            Debug.Log("player picked up boots");
            pmsl.carrying = thisCarryable;
            visuals.SetActive(false);
            pmsl.SendMessage("changeCarry");
        }

        else if (Input.GetKeyDown(interact) && pmsl.carrying == thisCarryable && playerIn == true)
        {
            pmsl.carrying = null;
            visuals.SetActive(true);
            pmsl.SendMessage("changeCarry");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = true;
            Debug.Log("player in zone");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
            Debug.Log("player left zone");
        }
    }
}
