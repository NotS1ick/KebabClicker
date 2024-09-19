using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyFunction : MonoBehaviour
{
    public Button buyAutoClicker;
    public Button buyCpsMultiplier;
    public TextMeshProUGUI buyAutoClickerText;
    public TextMeshProUGUI buyCpsMultiplierText;
    public static float priceOfAutoClicker = 10;
    public static float priceOfCpsMultiplier = 30;
    private static int TimesBought;
    private KebabClick kebabClickInstance;

    void Start()
    {
        kebabClickInstance = FindObjectOfType<KebabClick>();
        
        buyAutoClicker.onClick.AddListener(buyAutoClickerMethod);
        buyCpsMultiplier.onClick.AddListener(buyCpsMultiplierMethod);
        
        UpdateButtonTexts();
    }

    void Update()
    {
        buyAutoClicker.interactable = KebabClick.timesPressed >= priceOfAutoClicker;
        buyCpsMultiplier.interactable = KebabClick.timesPressed >= priceOfCpsMultiplier;
    }

    public void buyAutoClickerMethod()
    {
        KebabClick.timesPressed -= priceOfAutoClicker;
        priceOfAutoClicker = Mathf.RoundToInt(priceOfAutoClicker * 1.5f);
        if (TimesBought >= 10)
        {
            priceOfAutoClicker = Mathf.RoundToInt(priceOfAutoClicker * 2);
        }
        TimesBought++;
        
        if (kebabClickInstance != null)
        {
            kebabClickInstance.UpdateUi();
        }
        else
        {
            Debug.LogWarning("KebabClick instance not found!");
        }
        
        UpdateButtonTexts();
    }

    public void buyCpsMultiplierMethod()
    {
        KebabClick.timesPressed -= priceOfCpsMultiplier;
        priceOfCpsMultiplier = Mathf.RoundToInt(priceOfCpsMultiplier * 1.5f);
        
        if (kebabClickInstance != null)
        {
            kebabClickInstance.UpdateUi();
        }
        else
        {
            Debug.LogWarning("KebabClick instance not found!");
        }
        
        UpdateButtonTexts();
    }

    private void UpdateButtonTexts()
    {
        buyAutoClickerText.text = $"{priceOfAutoClicker}";
        buyCpsMultiplierText.text = $"{priceOfCpsMultiplier}";
    }
}