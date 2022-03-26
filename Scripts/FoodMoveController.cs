using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class FoodMoveController : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    private Surface surface;
    private float speed = 4;
    private Rigidbody rigidbody;
    private FoodSpawner foodSpawner;

    void Awake()
    {
        speed = FindObjectOfType<Level>().Config.Speed;
        foodSpawner = GetComponentInParent<FoodSpawner>();
        surface = foodSpawner.Surface;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotate();
        Move(direction);
        rigidbody.MovePosition(rigidbody.position + (direction * speed * Time.deltaTime));

        if (rigidbody.transform.position.y < - 22f)
        {
            Destroy(gameObject);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = surface.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (speed * Time.deltaTime);

        rigidbody.MovePosition(rigidbody.position + offset);
    }

    private void Rotate()
    {
        transform.Rotate(Vector3.up, Time.deltaTime);
    }
}
