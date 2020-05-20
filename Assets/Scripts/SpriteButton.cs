using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SpriteButton : AllySpawnerComponet
{
    Camera mainCamera;
    [SerializeField]
    UnityEvent onClick;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            var mousePos = Input.mousePosition; //mousePos.z = 0;
            var ray = mainCamera.ScreenPointToRay(mousePos);
            var hit = Physics2D.RaycastAll(ray.origin, ray.direction, 100);
            if (hit.Length > 1) return;
            //if (hit.transform.name != transform.name) return;
            onClick.Invoke();
        }
    }
}
