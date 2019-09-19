using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackController : MonoBehaviour {
    public List<GameObject> Racks;
    private int currentIndex;

    private void Awake() {
        currentIndex = 0;
        for (int i = 0; i < Racks.Count; i++) {
            Racks[i].SetActive(false);
        }
        if (Racks.Count == 0) {
            return;
        }
        Racks[currentIndex].SetActive(true);
    }

    public void Next() {
        if (Racks.Count == 0) {
            return;
        }
        Racks[currentIndex].SetActive(false);
        currentIndex++;
        currentIndex %= Racks.Count;
        Racks[currentIndex].SetActive(true);
    }

    public void Previous() {
        if (Racks.Count == 0) {
            return;
        }
        Racks[currentIndex].SetActive(false);
        currentIndex--;
        if (currentIndex < 0) {
            currentIndex = Racks.Count - 1;
        }
        Racks[currentIndex].SetActive(true);
    }
}
