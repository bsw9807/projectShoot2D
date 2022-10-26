using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBoomCountViewer : MonoBehaviour
{
    [SerializeField]
    private Weapon weapon;
    private TextMeshProUGUI textBombCount;

    private void Awake()
    {
        textBombCount = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textBombCount.text = "x " + weapon.BombCount;
    }
}
