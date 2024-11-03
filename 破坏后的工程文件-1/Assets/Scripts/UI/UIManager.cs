using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public PlayerStat playerStat;
    [Header("�¼�����")]
    public CharacterEventSo healthEvent;

    public void OnEnable()
    {
        healthEvent.OnEventRaised += OnHealthEvent;
    }

    private void OnDisable()
    {
        healthEvent.OnEventRaised -= OnHealthEvent;
    }

    private void OnHealthEvent(Character character)
    {
        var persentage = character.health / character.maxHealth;
        playerStat.OnHealthChange(persentage);
    }

}
