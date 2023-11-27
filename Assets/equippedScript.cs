using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equippedScript : MonoBehaviour
{
    public GameObject equipped;
    public playerMovementScript pms;
    public int gravityToRaise = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeEquippedPlayer(GameObject change)
    {
        equipped = change;
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        int location = equipped.ToString().IndexOf("(");
        GameObject boots = this.transform.Find(equipped.ToString().Substring(0, location - 1)).gameObject;
        boots.SetActive(true);
        int countToRaise=0;
        int count = 0;
        foreach (Transform child in this.transform)
        {
            if(child.gameObject.activeSelf == true)
            {
                countToRaise += gravityToRaise;
                countToRaise *= count;
            }
            count += 1;
        }
        pms.gravity = -30 - countToRaise; 
    }
}
