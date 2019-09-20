using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonController : MonoBehaviour {

    [SerializeField] private Button characterButton = null;
    [SerializeField] private Button characterButtonTop = null;
    [SerializeField] private CharacterController characterController = null;
    [SerializeField] private GameObject ConfirmScreen = null;
    [SerializeField] private TMPro.TextMeshProUGUI chancePercentageField = null;
    [SerializeField] private TMPro.TextMeshProUGUI nameField = null;
    [SerializeField] private Image dungeonImage = null;
    private Dungeon currentDungeon;

    private void OnEnable() {
        ConfirmScreen.SetActive(false);
    }

    public void ShowConfirmScreen(Dungeon dungeon) {
        ConfirmScreen.SetActive(true);
        nameField.text = dungeon.Name;
        chancePercentageField.text = GetChancePercentage(dungeon).ToString() + "%";
        dungeonImage.sprite = dungeon.GetComponentInChildren<Image>().sprite;
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
        float exploreSpeed = 100;
        characterButton.interactable = false;
        characterButtonTop.gameObject.SetActive(false);
        RectTransform characterPos = characterButton.GetComponent<RectTransform>();
        Vector2 startpos = characterPos.anchoredPosition;
        Transform parent = currentDungeon.transform.parent;
        Vector2 dungeonPos = parent.GetComponent<RectTransform>().anchoredPosition + new Vector2(0, -50);
        while (Vector2.Distance(characterPos.anchoredPosition, dungeonPos) > 0.1f) {
            characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, dungeonPos, exploreSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        float timeExploring = 0;
        Vector2 randomPos = GetRandomPosNearCurrentDungeon();
        while (timeExploring < 5) {
            if (Vector2.Distance(characterPos.anchoredPosition, randomPos) > 0.1f) {
                characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, randomPos, exploreSpeed * Time.deltaTime);
            } else {
                randomPos = GetRandomPosNearCurrentDungeon();
            }
            timeExploring += Time.deltaTime;
            yield return null;

        }

        // move outside
        while (Vector2.Distance(characterPos.anchoredPosition, dungeonPos) > 0.1f) {
            characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, dungeonPos, exploreSpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1);

        // move home
        while (Vector2.Distance(characterPos.anchoredPosition, startpos) > 0.1f) {
            characterPos.anchoredPosition = Vector2.MoveTowards(characterPos.anchoredPosition, startpos, exploreSpeed * Time.deltaTime);
            yield return null;
        }
        characterButton.interactable = true;
        characterButtonTop.gameObject.SetActive(true);
    }

    private Vector2 GetRandomPosNearCurrentDungeon() {
        Transform parent = currentDungeon.transform.parent;
        RectTransform dungeonPos = parent.GetComponent<RectTransform>();
        Vector2 pos = dungeonPos.anchoredPosition;
        pos += new Vector2(UnityEngine.Random.Range(0, 60f), UnityEngine.Random.Range(0, 60f));
        return pos;
    }

}
