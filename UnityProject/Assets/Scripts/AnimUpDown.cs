using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimUpDown : MonoBehaviour {
    [SerializeField] private float frequency = 1;
    [SerializeField] private float distMultiplier = 10;
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        Vector2 tempPos = rectTransform.anchoredPosition;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * distMultiplier;
        rectTransform.anchoredPosition = tempPos;
    }
}
