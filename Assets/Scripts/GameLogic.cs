using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
<<<<<<< HEAD
    public int problems;

    public GameObject[] emojiList;
    // Start is called before the first frame update
    void Start()
    {
=======
    public GameObject[] emojiList;
    public int heldEmojiId;
    // Start is called before the first frame update
    void Start()
    {
        heldEmojiId = -1;
>>>>>>> origin/bisby
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< HEAD

    public void unlockEmoji(int id)
    {
        emojiList[id].GetComponent<Emoji>().setUnlocked(true);
    }

    public void solve(int id)
    {
        Debug.Log("solved " + id);
        --problems;
        if (problems == 0)

            winGame();
    }

    void winGame()
    {
        Debug.Log("Game won");
    }
=======
>>>>>>> origin/bisby
}
