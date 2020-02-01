using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoreButton : MonoBehaviour
{
    public GameObject inv;
    public bool invActive;
    public bool tasksActive;
    public GameObject invButton;
    public GameObject tasksButton;
    // Start is called before the first frame update
    void Start()
    {
        invActive = false;
        tasksActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayInventory()
    {
        invActive = !invActive;
        inv.SetActive(invActive);
        tasksButton.SetActive(!invActive);
    }

    public void displayTasks()
    {
        tasksActive = !tasksActive;
        //tasks.SetActive(tasksActive);
        invButton.SetActive(!tasksActive);
    }

    public void displayLore0()
    {
        Text t = GameObject.Find("Inventario/Canvas/LoreText").GetComponent<Text>();

        t.text = "Lore0";
        
    }
}
