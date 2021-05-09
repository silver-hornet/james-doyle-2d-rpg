using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    public GameObject audioMan;
    //public GameObject battleMan;

    void Start()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>(); // does the same thing as lines 19 and 20, but just in one line instead
        }

        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }

        if (GameManager.instance == null)
        {
            Instantiate(gameMan);
        }

        if (AudioManager.instance == null)
        {
            Instantiate(audioMan);
        }

        //if (BattleManager.instance == null)
        //{
        //    Instantiate(battleMan);
        //}
    }
}
