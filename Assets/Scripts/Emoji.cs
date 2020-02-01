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
    public bool slotted;
    public Vector2 originalPos;
    public Vector2 offset;
    public Vector2 slotPos;


    // Start is called before the first frame update
    void Start()
    {
        slotted = false;
        clicked = false;
        dt = 0.0f;
        if (unlocked) setVisible(true);
        else setVisible(false);
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1.0f / 60.0f && !slotted)
        {
            dt -= 1.0f / 60.0f;
            if (Input.GetKey("right"))
                this.transform.position = this.transform.position + new Vector3(0.1f, 0.0f, 0.0f);
            if (Input.GetKey("left"))
                this.transform.position = this.transform.position + new Vector3(-0.1f, 0.0f, 0.0f);
        }

        if (visible)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        if (Input.GetMouseButtonDown(0) && unlocked)
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
            if (slotted)
            {
                this.transform.position = slotPos;
            }
        }
    }

    public void setUnlocked(bool b)
    {
        unlocked = b;
        setVisible(true);
    }

    public void setVisible(bool b)
    {
        visible = b;
    }

    private void OnTriggerEnter2D(Collider2D hitCollider)
    {
        if (hitCollider.gameObject.tag == "problema")
        {
            hitCollider.gameObject.GetComponent<Problema>().addIngredient(id);
        }

        if (hitCollider.gameObject.tag == "jardin")
        {
            hitCollider.gameObject.GetComponent<Jardín>().addIngredient(id);
        }

        if (hitCollider.gameObject.tag == "slot")
        {
            slotPos = hitCollider.gameObject.GetComponent<Slot>().transform.position;
            slotted = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D hitCollider)
    {
        if (hitCollider.gameObject.tag == "problema")
        {
            hitCollider.gameObject.GetComponent<Problema>().delIngredient(id);
        }

        if (hitCollider.gameObject.tag == "jardin")
        {
            hitCollider.gameObject.GetComponent<Jardín>().delIngredient(id);
        }

        if (hitCollider.gameObject.tag == "slot")
        {
            slotted = false;
        }
    }


}
