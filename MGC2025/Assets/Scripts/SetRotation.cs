using UnityEngine;

public class SetRotation : MonoBehaviour
{
    public Vector3 rotation;
    public void Rotate()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
}
