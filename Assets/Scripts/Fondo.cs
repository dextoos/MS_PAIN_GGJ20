using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{

    public float dt;
    // Start is called before the first frame update
    void Start()
    {
        dt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1.0f/60.0f)
        {
            dt -= 1.0f / 60.0f;
            if (Input.GetKey("right"))
                this.transform.position = this.transform.position + new Vector3(0.1f, 0.0f, 0.0f);
            if (Input.GetKey("left"))
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0.0f, 0.0f);
        }
    }
}
