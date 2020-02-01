using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{
    public string scene ="EmojiTon";

    public void GameStart() {
        SceneManager.LoadScene(scene);
    }
}
