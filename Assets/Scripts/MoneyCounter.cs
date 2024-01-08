using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField] private int quantityMoney = 0;
    [SerializeField] private TMP_Text textInCounter;
    private int receivedMoney = 0;
    private bool isChanging = false;
    private void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            receivedMoney = 10;
        }
        if (isChanging == false && receivedMoney != 0)
        {
            ReceivingMoney();
        }
    }


    private void ReceivingMoney()
    {
        isChanging = true;
        StartCoroutine(IncreaseMoney());
    }

    private IEnumerator IncreaseMoney()
    {
        int targetMoney = quantityMoney + receivedMoney;
        while (quantityMoney < targetMoney)
        {
            quantityMoney++;
            textInCounter.text = quantityMoney.ToString();
            yield return new WaitForSeconds(0.05f); 
        }
        receivedMoney = 0;
        isChanging = false;
    }
}



