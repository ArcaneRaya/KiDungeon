using UnityEngine;
using System.Collections;
using System;

public class ButtonHeadWear : MonoBehaviour {
    public HeadWear HeadWear;
    public CharacterController CharacterController;

    private void Awake() {
        GameEvents.UpdateGearAction += UpdateButton;
        UpdateButton();
    }

    private void UpdateButton() {
        if (CharacterController.AvailableHeadWears.Contains(HeadWear)) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        GameEvents.UpdateGearAction -= UpdateButton;
    }
}
