using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectableAmountText;
    [SerializeField] Transform magicBar;
    [SerializeField] PlayerController playerController;


    private void Update()
    {
        DisplayMagicBar();

    }



    public void DisplayCollected()
    {
        collectableAmountText.text = playerController.collectableAmount.ToString();
    }

    void DisplayMagicBar()
    {
        float percent = playerController.currentHealth / 100;

        magicBar.localScale = new Vector3(percent, 1, 1);
    }



}
