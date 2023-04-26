using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    float destroyTime = 2f;
    float timer = 0;
    void Start()
    {
        transform.parent = null; 
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            Destroy(this.gameObject);
        }
    }
}
