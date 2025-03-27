using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions;
    public Transform center;
    public Transform idlePosition;

    bool isMouseDown;

    Vector3 currentPosition;

    public float maxLength;
    public float bottomBoundary;
    public float leftBoudary;

    public GameObject birdPrefab;

    Rigidbody2D bird;
    Collider2D birdCollider;

    public float birdPositionOffset;
    public float force;

    public int birds_remaining;


    void Start() {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0, stripPositions[0].position);
        lineRenderers[1].SetPosition(0, stripPositions[1].position);

        birds_remaining = 3;
        CreateBird();
    }

    void CreateBird()
    {
        if (birds_remaining == 0) {
            Destroy(gameObject);
        }
        else {

            bird = Instantiate(birdPrefab).GetComponent<Rigidbody2D>();
            birdCollider = bird.GetComponent<Collider2D>();
            birdCollider.enabled = false;

            ResetStrips();
        }
        birds_remaining--;
    }

    void Update() {
        if (isMouseDown) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10;

            currentPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPosition = center.position + Vector3.ClampMagnitude(currentPosition - center.position, maxLength);

            currentPosition = ClampBoundary(currentPosition);

            SetStrips(currentPosition);

            if (birdCollider) {
                birdCollider.enabled = true;
            }
        }
        else
        {
            ResetStrips();
        }
    }

    private void OnMouseDown() {
        isMouseDown = true;
    }

    private void OnMouseUp() {
        isMouseDown = false;
        Shoot();
    }

    void Shoot()
    {
        Vector3 birdForce = (currentPosition - center.position) * force * -1;
        bird.linearVelocity = birdForce;

        bird = null;
        birdCollider = null;

        if (birds_remaining > 0) Invoke("CreateBird", 2);
        else Invoke("CreateBird", 7);
    }

    void ResetStrips() {
        currentPosition = idlePosition.position;
        SetStrips(currentPosition);
    }

    void SetStrips(Vector3 position) {
        lineRenderers[0].SetPosition(1, position);
        lineRenderers[1].SetPosition(1, position);

        if (bird) {
            Vector3 dir = position - center.position;
            bird.transform.position = position + dir.normalized * birdPositionOffset;
            bird.transform.right = -dir.normalized;
        }
    }

    Vector3 ClampBoundary(Vector3 vector)
    {
        vector.y = Mathf.Clamp(vector.y, bottomBoundary, 1000);
        vector.x = Mathf.Clamp(vector.x, leftBoudary, 1000);
        return vector;
    }

    public bool Check() {
        return birds_remaining == -1;
    }
}