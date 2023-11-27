using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScriptOutside : MonoBehaviour
{
    public bool playerIn = false;
    public KeyCode interact;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact) && playerIn == true)
        {
            playerIn = false;
            SceneManager.LoadScene("Lab");

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
