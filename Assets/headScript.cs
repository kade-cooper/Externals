using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour
{
    public GameObject whole;
    public bool hasBeenShoved=false;
    public float velocityToSmash = 2;
    public GameObject blood;
    public playerMovementScript pms;


    private void Start()
    {
        pms = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovementScript>();
    }
    //ADD TO IF LATER   other.attachedRigidbody.velocity.magnitude>velocityToSmash
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("stomp") && pms.velocity.y<=velocityToSmash)
        {
            Instantiate(blood, this.transform.position, Quaternion.identity);
            Destroy(whole);
        }
    }
}
