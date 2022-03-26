using UnityEngine;
using UnityEngine.Events;
using System;

public class DragBox : MonoBehaviour
{
    private Level level;
    private DragBox selectedBox;
    [SerializeField] private ParticleSystem particleTrue;
    [SerializeField] private ParticleSystem particleFalse;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedBox == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    selectedBox = hit.collider.gameObject.GetComponent<DragBox>();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selectedBox != null)
            {
                selectedBox = null;
            }
        }

        if (selectedBox != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, 
                                           Input.mousePosition.y, 
                                           Camera.main.WorldToScreenPoint(selectedBox.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            selectedBox.transform.position = new Vector3(worldPosition.x, transform.position.y, transform.position.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNea = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNea);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear,worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Collider>().enabled = false;
        Collect(other.GetComponent<Food>());
    }
    
    private void Collect(Food food)
    {
        if (level.IsNeededFood(food))
        {
            level.CollectTrueFood(food);
            particleTrue.Play();
        }
        else
        {
            level.CollectFalseFood(food);
            particleFalse.Play();
        }
    }
}
