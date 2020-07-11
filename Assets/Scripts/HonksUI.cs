using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HonksUI : MonoBehaviour
{
    public TMP_Text honkText;

    GameManager gm;

    private void Start()
    {
        gm = GameManager.instance;
        gm.honkUpdate += UpdateHonks;
    }

    public void UpdateHonks(int honks)
    {
        honkText.text = $"{honks}";
    }
}
