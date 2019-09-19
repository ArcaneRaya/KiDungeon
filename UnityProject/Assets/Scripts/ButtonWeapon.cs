using UnityEngine;
using System.Collections;
using System;

public class ButtonWeapon : MonoBehaviour {
    public Weapon Weapon;
    public CharacterController CharacterController;

    private void Awake() {
        GameEvents.UpdateGearAction += UpdateButton;
        UpdateButton();
    }

    private void UpdateButton() {
        if (CharacterController.AvailableWeapons.Contains(Weapon)) {
            gameObject.SetActive(true);
        } else {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy() {
        GameEvents.UpdateGearAction -= UpdateButton;
    }
}
