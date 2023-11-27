using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoSender : MonoBehaviour 
{
    public GameObject equipped;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelWasLoaded(int level)
    {
        GameObject.FindGameObjectWithTag("Player").transform.Find("equipped").gameObject.SendMessage("changeEquippedPlayer", equipped);
    }

    public void changeEquippedSender(GameObject on)
    {
        equipped = on;
    }
}
