using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotInteractble : MonoBehaviour
{

    public bool playerIn = false;
    public GameObject equipped;
    public KeyCode interact;
    public playerMovementScriptLab pmsl;
    public GameObject infoSender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact) && pmsl.carrying != null && playerIn == true)
        {   
            equipped = pmsl.carrying;
            changeEquipped();
            pmsl.carrying = null;
            pmsl.SendMessage("changeCarry");

        }
        else if (Input.GetKeyDown(interact) && pmsl.carrying == null && playerIn == true)
        {
            
            pmsl.carrying = equipped;
            pmsl.SendMessage("changeCarry");
            equipped = null;
            changeEquipped();

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

    public void changeEquipped()
    {
        Transform child = this.gameObject.transform.GetChild(0);
        foreach (Transform equippable in child)
        {
            equippable.gameObject.SetActive(false);
        }
        int location = equipped.ToString().IndexOf("(");
        child.transform.Find(equipped.ToString().Substring(0, location - 1)).gameObject.SetActive(true);
        infoSender.SendMessage("changeEquippedSender", equipped);
    }


}
