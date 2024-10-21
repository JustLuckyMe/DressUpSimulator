using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemType
{
    Hat,
    Shirt
}

public class ItemSelector : MonoBehaviour
{
    [System.Serializable]
    public class ItemData
    {
        public string itemName;
        public GameObject itemGO;
    }

    public List<ItemData> ItemList = new List<ItemData>();
    public int currentItemIndex = 0;
    private bool isSelectionEnabled = true;
    [SerializeField] private TextMeshProUGUI itemNameUI;

    private void Start()
    {
        if (ItemList.Count > 0)
        {
            Debug.Log("Current Item: " + ItemList[currentItemIndex].itemName);
            EnableCurrentItem();
        }
        else
        {
            Debug.Log("Item list is empty.");
        }
    }

    public void NextItem()
    {
        if (!isSelectionEnabled || ItemList.Count == 0) return;

        DisableCurrentItem();
        currentItemIndex = (currentItemIndex + 1) % ItemList.Count;
        Debug.Log("Current Item: " + ItemList[currentItemIndex].itemName);
        EnableCurrentItem();
        UpdateUI();
    }

    public void PreviousItem()
    {
        if (!isSelectionEnabled || ItemList.Count == 0) return;

        DisableCurrentItem();
        currentItemIndex = (currentItemIndex - 1 + ItemList.Count) % ItemList.Count;
        Debug.Log("Current Item: " + ItemList[currentItemIndex].itemName);
        EnableCurrentItem();
        UpdateUI();
    }

    private void EnableCurrentItem()
    {
        ItemData currentItemData = ItemList[currentItemIndex];
        if (currentItemData.itemGO != null)
        {
            currentItemData.itemGO.SetActive(true);
        }
        //Debug.Log("Enabled Item: " + currentItemData.itemName);
    }


    public void DisableCurrentItem()
    {
        if (ItemList.Count > 0)
        {
            ItemData currentItemData = ItemList[currentItemIndex];
            if (currentItemData.itemGO != null)
            {
                currentItemData.itemGO.SetActive(false);
            }
            Debug.Log("Disabled Item: " + currentItemData.itemName);
        }
    }


    public void DisableAllItems()
    {
        foreach (ItemData item in ItemList)
        {
            if (item.itemGO != null)
            {
                item.itemGO.SetActive(false);
            }
        }
        Debug.Log("All items disabled.");
    }

    private void UpdateUI()
    {
        itemNameUI.text = ItemList[currentItemIndex].itemName;
    }

    public void UpdateSelection()
    {
        //DisableAllItems();
        EnableCurrentItem();
    }
}
