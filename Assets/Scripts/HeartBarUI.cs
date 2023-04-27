using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartBarUI : MonoBehaviour
{

    [SerializeField] private Image heartFill;
    [SerializeField] private Character character;
    void Start()
    {
        UpdateHealtBar();
    }

    void OnEnable()
    {
        character.onTakeDamage += UpdateHealtBar;
    }

    private void OnDesable()
    {
        character.onTakeDamage -= UpdateHealtBar;
    }



    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }

    void UpdateHealtBar()
    {
        heartFill.fillAmount = (float)character.CurHp / (float)character.MaxHp;
    }
}
