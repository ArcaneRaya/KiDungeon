using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour {

    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject ConfirmScreen = null;
    [SerializeField] private TMPro.TextMeshProUGUI chancePercentageField = null;
    [SerializeField] private TMPro.TextMeshProUGUI nameField = null;
    private Dungeon currentDungeon;

    private void OnEnable() {
        ConfirmScreen.SetActive(false);
    }

    public void ShowConfirmScreen(Dungeon dungeon) {
        ConfirmScreen.SetActive(true);
        nameField.text = dungeon.Name;
        chancePercentageField.text = GetChancePercentage(dungeon).ToString() + "%";
        currentDungeon = dungeon;
    }

    public void ConfirmDungeon() {
        ConfirmScreen.SetActive(false);
    }

    public void CancelDungeon() {
        currentDungeon = null;
        ConfirmScreen.SetActive(false);
    }

    private int GetChancePercentage(Dungeon dungeon) {
        int magicScore = Mathf.Min(characterController.TotalMagic * 100 / dungeon.Stats.Magic, 100);
        int speedScore = Mathf.Min(characterController.TotalSpeed * 100 / dungeon.Stats.Speed, 100);
        int strenghtScore = Mathf.Min(characterController.TotalStrength * 100 / dungeon.Stats.Strength, 100);

        switch (dungeon.Type) {
            case DungeonType.Magic:
                Debug.Log(characterController.TotalMagic);
                return magicScore;
            case DungeonType.Strength:
                Debug.Log(characterController.TotalStrength);
                return strenghtScore;
            case DungeonType.Speed:
                Debug.Log(characterController.TotalSpeed);
                return speedScore;
            default:
                return 100;
        }
    }

}
