using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
{

    public GameObject shoppingList;
    private bool shoppingListActiveCheck;

    // Start is called before the first frame update
    void Start()
    {
        shoppingList.SetActive(false);
        shoppingListActiveCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(shoppingListActiveCheck);
        if (Input.GetKeyDown(KeyCode.E))
        {
            shoppingListActiveCheck = !shoppingListActiveCheck;
            shoppingList.SetActive(shoppingListActiveCheck);
        }
    }
}
