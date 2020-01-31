using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{
    public float dt;
    public bool unlocked;
    public bool visible;

    // Start is called before the first frame update
    void Start()
    {
        dt = 0.0f;
        unlocked = true;
        visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (visible)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePos);


            if (hitCollider != null && hitCollider.gameObject.name == this.name)
            {
                setVisible(!visible);
            }
        }
    }

    public void setUnlocked(bool b)
    {
        unlocked = b;
    }

    public void setVisible(bool b)
    {
        visible = b;
    }
}
