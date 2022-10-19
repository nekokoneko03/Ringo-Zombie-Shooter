using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActiveItem : MonoBehaviour
{
    [SerializeField] private ActiveItem activeItem;
    [SerializeField] private float activeTime;
    [SerializeField] private float coolDownTime;

    private void Start()
    {
        activeTime = activeItem.activeTime;
        coolDownTime = activeItem.coolDown;
    }

    private void Update()
    {

        switch (activeItem.currentState)
        {
            case currentState.Ready:
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    activeItem.OnUse(this.gameObject);
                    activeItem.currentState = currentState.Active;
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
                    activeItem.currentState = currentState.Cooldown;
                    activeTime = activeItem.activeTime;
                    break;
                }else
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
                    activeItem.currentState = currentState.Ready;
                    coolDownTime = activeItem.coolDown;
                    break;
                }
        }
    }
}

public enum currentState
{
    Ready,
    Active,
    Cooldown,
}
