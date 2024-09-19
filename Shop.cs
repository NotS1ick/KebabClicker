using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopMenu;
    public static bool ShopIsOpen;

    void Start()
    {
        ShopMenu.SetActive(false);
        ShopIsOpen = false;
    }

    public void OpenShop()
    {
        if (!ShopIsOpen && !Pause.isPaused)
        {
            ShopMenu.SetActive(true);
            ShopIsOpen = true;
        }
    }

    public void CloseShop()
    {
        if (ShopIsOpen && !Pause.isPaused)
        {
            ShopMenu.SetActive(false);
            ShopIsOpen = false;
        }
    }
}