using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveItem : MonoBehaviour
{
    [SerializeField] private ActiveItem activeItem;
    [SerializeField] private float activeTime;
    [SerializeField] private float coolDownTime;
    [SerializeField] private currentState currentState;

    private void Start()
    {
        activeItem = GetComponent<ActiveItem>();
        activeTime = activeItem.activeItemProperties.activeTime;
        coolDownTime = activeItem.activeItemProperties.coolDownTime;
        currentState = activeItem.currentState;
    }

    private void Update()
    {

        switch (currentState)
        {
            case currentState.Ready:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (activeItem == null) return;
                    activeItem.OnUse(this.gameObject);
                    currentState = currentState.Active;
                    break;
                }
                else
                {
                    break;
                }

            case currentState.Active:
                activeTime -= Time.deltaTime;

                if (activeTime <= 0)
                {
                    currentState = currentState.Cooldown;
                    activeItem.OnEnd();
                    if (activeItem.activeItemProperties == null) return;
                    activeTime = activeItem.activeItemProperties.activeTime;
                    break;
                }
                else
                {
                    break;
                }

            case currentState.Cooldown:
                if (coolDownTime > 0)
                {
                    coolDownTime -= Time.deltaTime;
                    break;
                }
                else
                {
                    currentState = currentState.Ready;
                    if (activeItem.activeItemProperties == null) return;
                    coolDownTime = activeItem.activeItemProperties.coolDownTime;
                    break;
                }
        }
    }

    public void Init()
    {
        activeTime = activeItem.activeItemProperties.activeTime;
        coolDownTime = activeItem.activeItemProperties.coolDownTime;
        currentState = activeItem.currentState;
    }
}