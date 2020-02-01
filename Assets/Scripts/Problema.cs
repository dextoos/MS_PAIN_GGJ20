using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problema : MonoBehaviour
{
    public int id;
    public int[] ingredientes;
    public int[] solucion;
    public int[] reward;
    public GameLogic gl;
    bool solved;
    // Start is called before the first frame update
    void Start()
    {
        solved = false;
        gl = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addIngredient(int id)
    {
        int length = ingredientes.Length;
        int[] aux = new int[length + 1];
        for (int i = 0; i<length; ++i)
        {
            aux[i] = ingredientes[i];
        }
        aux[length] = id;
        ingredientes = aux;
        if (!solved && checkSolution())
        {
            giveReward();
            solveChecklist();
        }
    }

    public void delIngredient(int id)
    {
        int length = ingredientes.Length;
        int[] aux = new int[length - 1];
        int j = 0;
        for (int i = 0; i < length; ++i)
        {
            if (ingredientes[i] != id)
            {
                aux[j] = ingredientes[i];
                ++j;
            }
        }
        ingredientes = aux;
    }

    bool checkSolution()
    {
        if (ingredientes.Length != solucion.Length) return false;
        for (int i = 0; i<solucion.Length; ++i)
        {
            int sol = solucion[i];
            bool found = false;
            for (int j = 0; j<ingredientes.Length; ++j)
            {
                if (sol == ingredientes[j]) found = true;
            }
            if (!found) return false;
        }
        return true;
    }

    void giveReward()
    {
        solved = true;
        for (int i = 0; i<reward.Length; ++i)
        {
            gl.unlockEmoji(reward[i]);
        }
    }

    void solveChecklist()
    {
        gl.solve(id);
    }
}
