using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour {

    [SerializeField] private GameObject characterScreen = null;
    [SerializeField] private GameObject dungeonScreen = null;

    public void ShowCharacterScreen() {
        characterScreen.SetActive(true);
        dungeonScreen.SetActive(false);
    }

    public void ShowDungeonScreen() {
        characterScreen.SetActive(false);
        dungeonScreen.SetActive(true);
    }
}
