using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jardín : MonoBehaviour
{
    public bool[] ingredientes;
    public int[] soluciones;
    public int[] rewards;
    public float[] times;
    public bool[] solved;
    public float dt;

    public GameLogic gl;

    // Start is called before the first frame update
    void Start()
    {
        gl = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        for (int i = 0; i<times.Length; ++i)
        {
            times[i] = 0.0f;
            solved[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        dt += Time.deltaTime;
        if (dt > 1.0f / 60.0f)
        {
            for (int i = 0; i<ingredientes.Length; ++i)
            {
                if (ingredientes[i] == true && !solved[i])
                {
                    times[i] += 1.0f / 60.0f;
                    if (times[i] > 2.0f)
                    {
                        solved[i] = true;
                        gl.unlockEmoji(rewards[i]);
                    }
                }
            }
            dt -= 1.0f / 60.0f;
        }
    }

    public void addIngredient(int id)
    {
        for (int i = 0; i < soluciones.Length; ++i)
        {
            if (soluciones[i] == id)
            {
                ingredientes[i] = true;
                return;
            }
        }
    }

    public void delIngredient(int id)
    {
        for (int i = 0; i < soluciones.Length; ++i)
        {
            if (soluciones[i] == id)
            {
                ingredientes[i] = false;
                return;
            }
        }
    }
}
