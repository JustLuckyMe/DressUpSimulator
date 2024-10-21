using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomizeScript : MonoBehaviour
{
    [SerializeField] ItemSelector HatList;
    [SerializeField] ItemSelector ShirtList;
    [SerializeField] ItemSelector PantsList;
    [SerializeField] ItemSelector ShoesList;

    // rando menu
    [SerializeField] Toggle hatToggle;
    [SerializeField] Toggle shirtToggle;
    [SerializeField] Toggle pantsToggle;
    [SerializeField] Toggle shoesToggle;

    private bool randoHat;
    private bool randoShirt;
    private bool randoPants;
    private bool randoShoes;

    private void Start()
    {
        // Ensure toggles are assigned
        if (hatToggle == null || shirtToggle == null || pantsToggle == null || shoesToggle == null)
        {
            Debug.LogWarning("One or more toggles are not assigned.");
            return;
        }

        // Initialize the toggle state
        randoHat = hatToggle.isOn;
        randoShirt = shirtToggle.isOn;
        randoPants = pantsToggle.isOn;
        randoShoes = shoesToggle.isOn;

        hatToggle.onValueChanged.AddListener((bool isOn) => { randoHat = isOn; });
        shirtToggle.onValueChanged.AddListener((bool isOn) => { randoShirt = isOn; });
        pantsToggle.onValueChanged.AddListener((bool isOn) => { randoPants = isOn; });
        shoesToggle.onValueChanged.AddListener((bool isOn) => { randoShoes = isOn; });
    }

    public void RandomizeItems()
    {
        if (randoHat) RandomizeHat();
        if (randoShirt) RandomizeShirt();
        if (randoPants) RandomizePants();
        if (randoShoes) RandomizeShoes();
    }

    #region Random Funcs
    private void RandomizeHat()
    {
        if (HatList.ItemList.Count > 0)
        {
            HatList.DisableCurrentItem(); // Disable the current item
            HatList.currentItemIndex = Random.Range(0, HatList.ItemList.Count);
            Debug.Log("Randomized Hat to index: " + HatList.currentItemIndex);
            HatList.UpdateSelection();
        }
    }

    private void RandomizeShirt()
    {
        if (ShirtList.ItemList.Count > 0)
        {
            ShirtList.DisableCurrentItem(); // Disable the current item
            ShirtList.currentItemIndex = Random.Range(0, ShirtList.ItemList.Count);
            Debug.Log("Randomized Shirt to index: " + ShirtList.currentItemIndex);
            ShirtList.UpdateSelection();
        }
    }

    private void RandomizePants()
    {
        if (PantsList.ItemList.Count > 0)
        {
            PantsList.DisableCurrentItem(); // Disable the current item
            PantsList.currentItemIndex = Random.Range(0, PantsList.ItemList.Count);
            Debug.Log("Randomized Pants to index: " + PantsList.currentItemIndex);
            PantsList.UpdateSelection();
        }
    }

    private void RandomizeShoes()
    {
        if (ShoesList.ItemList.Count > 0)
        {
            ShoesList.DisableCurrentItem(); // Disable the current item
            ShoesList.currentItemIndex = Random.Range(0, ShoesList.ItemList.Count);
            Debug.Log("Randomized Shoes to index: " + ShoesList.currentItemIndex);
            ShoesList.UpdateSelection();
        }
    }
    #endregion
}
