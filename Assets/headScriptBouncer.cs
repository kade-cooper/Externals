using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScriptBouncer : MonoBehaviour
{
    public GameObject whole;
    public bool hasBeenShoved=false;
    public float velocityToSmash = 2;
    public GameObject blood;
    public playerMovementScript pms;
    public float bounce;


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
            pms.velocity += new Vector3(0, bounce, 0);
            Instantiate(blood, this.transform.position, Quaternion.identity);
            Destroy(whole);
        }
    }
}
