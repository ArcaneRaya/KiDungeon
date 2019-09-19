using UnityEngine;
using System.Collections;
using System;

public class ButtonArmorSet : MonoBehaviour {
    public ArmorSet ArmorSet;
    public CharacterController CharacterController;

    private void Awake() {
        GameEvents.UpdateGearAction += UpdateButton;
        UpdateButton();
    }

    private void UpdateButton() {
        if (CharacterController.AvailableArmorSets.Contains(ArmorSet)) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        GameEvents.UpdateGearAction -= UpdateButton;
    }
}
