using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    public bool playerIn = false;
    public KeyCode interact;
    public playerMovementScriptLab pmsl;
    public infoSender infosender;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact) && pmsl.carrying == null && playerIn == true)
        {
            playerIn = false;
            SceneManager.LoadScene("SampleScene");

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
