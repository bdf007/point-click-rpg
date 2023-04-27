using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickController : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            Debug.Log("Click");
            Click();
        }
    }

    void Click()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        // Shoot a raycast from our position to what ever we are pointing at
        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            int hitLayer = hit.collider.gameObject.layer;

            // did we hit the ground
            if (hitLayer == LayerMask.NameToLayer("Ground"))
            {
                Player.Current.SetTarget(null);
                Player.Current.Controller.MoveToPosition(hit.point);

            }
            // Did we hit an enemy
            else if (hitLayer == LayerMask.NameToLayer("Enemy"))
            {
                Character enemy = hit.collider.GetComponent<Character>();
                Player.Current.SetTarget(enemy);
            }
        }
    }
}
