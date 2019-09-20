using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour {

    [SerializeField] private Button characterButton = null;
    [SerializeField] private CharacterController characterController = null;
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
        StartCoroutine(ExploreDungeon());
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

    private IEnumerator ExploreDungeon() {
        characterButton.interactable = false;
        RectTransform characterPos = characterButton.GetComponent<RectTransform>();
        Vector2 startpos = characterPos.anchoredPosition;
        Transform parent = currentDungeon.transform.parent;
        Debug.Log(parent);
        RectTransform dungeonPos = parent.GetComponent<RectTransform>();
        while (Vector2.Distance(characterPos.anchoredPosition, dungeonPos.anchoredPosition) > 0.1f) {
            characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, dungeonPos.anchoredPosition, 100 * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1);
        while (Vector2.Distance(characterPos.anchoredPosition, startpos) > 0.1f) {
            characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, startpos, 100 * Time.deltaTime);
            yield return null;
        }
        characterButton.interactable = true;
    }

}
