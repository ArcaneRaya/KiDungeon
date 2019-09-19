using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public int TotalMagic {
        get {
            return
                Base.Stats.Magic +
                (Weapon != null ? Weapon.Stats.Magic : 0) +
                (ArmorSet != null ? ArmorSet.Stats.Magic : 0) +
                (HeadWear != null ? HeadWear.Stats.Magic : 0);
        }
    }

    public int TotalStrength {
        get {
            return
                Base.Stats.Strength +
                (Weapon != null ? Weapon.Stats.Strength : 0) +
                (ArmorSet != null ? ArmorSet.Stats.Strength : 0) +
                (HeadWear != null ? HeadWear.Stats.Strength : 0);
        }
    }

    public int TotalSpeed {
        get {
            return
                Base.Stats.Speed +
                (Weapon != null ? Weapon.Stats.Speed : 0) +
                (ArmorSet != null ? ArmorSet.Stats.Speed : 0) +
                (HeadWear != null ? HeadWear.Stats.Speed : 0);
        }
    }

    public Character Base;
    public Weapon Weapon;
    public ArmorSet ArmorSet;
    public HeadWear HeadWear;

    public List<Weapon> AvailableWeapons;
    public List<ArmorSet> AvailableArmorSets;
    public List<HeadWear> AvailableHeadWears;

    [SerializeField] private Transform weaponContainer = null;
    [SerializeField] private Transform armorSetContainer = null;
    [SerializeField] private Transform headWearContainer = null;

    public void SetWeapon(Weapon weapon) {
        Weapon = weapon;
        for (int i = weaponContainer.childCount - 1; i >= 0; i--) {
            Destroy(weaponContainer.GetChild(i).gameObject);
        }
        RectTransform weaponRect = Instantiate(weapon.gameObject, weaponContainer).GetComponent<RectTransform>();
        weaponRect.anchoredPosition = Vector2.zero;
    }

    public void SetArmorSet(ArmorSet armorSet) {
        ArmorSet = armorSet;
        for (int i = armorSetContainer.childCount - 1; i >= 0; i--) {
            Destroy(armorSetContainer.GetChild(i).gameObject);
        }
        RectTransform armorRect = Instantiate(armorSet.gameObject, armorSetContainer).GetComponent<RectTransform>();
        armorRect.anchoredPosition = Vector2.zero;
    }

    public void SetHeadWear(HeadWear headWear) {
        HeadWear = headWear;
        for (int i = headWearContainer.childCount - 1; i >= 0; i--) {
            Destroy(headWearContainer.GetChild(i).gameObject);
        }
        RectTransform headwearRect = Instantiate(headWear.gameObject, headWearContainer).GetComponent<RectTransform>();
        headwearRect.anchoredPosition = Vector2.zero;
    }

    [ContextMenu("Invoke Gear Update")]
    public void InvokeGearUpdate() {
        if (GameEvents.UpdateGearAction != null) {
            GameEvents.UpdateGearAction();
        }
    }
}
