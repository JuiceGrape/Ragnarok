using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    [SerializeField] private float movementSpeed = 1.0f;
    [SerializeField] private float interactionDistance = 1.5f;

    private Character player;

    private Vector2? targetPos;
    private Targetable target;

    private Vector2 mousePos;

    private Enums.InputState moveButtonState = Enums.InputState.Invalid;

    float timeSinceMovementClick = 0.0f;
    void Start()
    {
        if (input != null)
        {
            input.OnMousePosChanged.AddListener(OnMousePosChanged);
            input.OnMovementChanged.AddListener(OnMovementStateChanged);
        }

        player = GetComponent<Character>();

        if (player == null)
        {
            throw new System.Exception("No character attached to the player controller");
        }
    }

    private void Update()
    {
        //Set target position if holding button. Don't attack while doing this.
        if (moveButtonState == Enums.InputState.Down)
        {
            if (timeSinceMovementClick > 0.1f)
            {
                target = null;
                targetPos = mousePos;
            }
            else
            {
                timeSinceMovementClick += Time.deltaTime;
            }
            
        }

        //Deal with moving towards target position or target
        //TODO: Pathfinding? Maybe?
        if (targetPos.HasValue)
        {
            if (MoveToTarget(targetPos.Value, movementSpeed * Time.deltaTime))
            {
                targetPos = null;
            }
        }
        else if (target != null)
        {
            if (target.IsAttackable())
            {
                if (MoveToTarget(target.transform.position, player.EquippedAttack.Range))
                {
                    var hittable = target as Hittable;
                    if (hittable != null)
                    {
                        player.Attack(hittable);
                    }
                    target = null; 
                }
            }
            else
            {
                if(MoveToTarget(target.transform.position, interactionDistance))
                {
                    var interactable = target as Interactable;
                    if (interactable != null)
                    {
                        player.Interact(interactable);
                    }
                    target = null; 
                }

            }
        }  
    }

    void OnMousePosChanged(Vector2 worldPos)
    {
        mousePos = worldPos;
    }

    bool MoveToTarget(Vector3 target, float stopDistance)
    {
        if (Vector2.Distance(transform.position, target) < stopDistance) //Check distance before moving so you can instantly stop if you're close enough
        {
            return true;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);

        return false;
    }

    void OnMovementStateChanged(Enums.InputState state)
    {
        moveButtonState = state;
        if (state == Enums.InputState.Down) //TODO: Hold down for continuous movement
        {
            timeSinceMovementClick = 0.0f;
            if (Targetable.CurrentTarget != null)
            {
                target = Targetable.CurrentTarget;
                targetPos = null;
            }
            else
            {
                targetPos = mousePos;
                target = null;
            }
        }
    }
}
