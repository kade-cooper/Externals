using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttkScript : MonoBehaviour
{

    public KeyCode attk1;
    public KeyCode attk2;
    public GameObject attkObject;
    public GameObject attkObject2;
    public float cooldown;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(attk1) && time<=0)
        {
            attkObject.SetActive(true);
            time = cooldown;
        }
        else if(Input.GetKey(attk2) && time <= 0)
        {
            attkObject2.SetActive(true);
            time = cooldown;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
