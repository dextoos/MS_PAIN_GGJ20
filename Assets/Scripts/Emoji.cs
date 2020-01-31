using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emoji : MonoBehaviour
{
    public int id;
    public float dt;
    public bool unlocked;
    public bool visible;
    public bool clicked;
    public Vector2 originalPos;
    public Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        clicked = false;
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
                clicked = true;
                originalPos = gameObject.transform.position;
                offset = mousePos - originalPos;
            }

            
        }

        if (clicked)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0.0f) - new Vector3(offset.x, offset.y, 0.0f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;

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
