using UnityEngine;

public class BackgroundParalaxe : MonoBehaviour
{
    [SerializeField]
    private float parralaxEffect;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += deltaMovement * parralaxEffect;
        lastCameraPosition = cameraTransform.position;
    }
}
