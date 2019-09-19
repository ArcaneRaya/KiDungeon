using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour {
    private enum StatType { Magic, Strength, Speed }
    [SerializeField] private TextMeshProUGUI statField;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private StatType statType;

    private void Update() {
        int value = 0;
        switch (statType) {
            case StatType.Magic:
                value = characterController.TotalMagic;
                break;
            case StatType.Strength:
                value = characterController.TotalStrength;
                break;
            case StatType.Speed:
                value = characterController.TotalSpeed;
                break;
            default:
                break;
        }
        statField.text = value.ToString();
    }
}
