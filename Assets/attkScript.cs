using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attkScript : MonoBehaviour
{

    public float time = 1f;
    public GameObject self;
    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(disableafter());
    }
    private void Start()
    {
        StartCoroutine(disableafter());
    }

    IEnumerator disableafter()
    {
        yield return new WaitForSeconds(time);
        self.gameObject.SetActive(false);
    }
}
