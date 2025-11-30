using UnityEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    public void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab);
        _bullet.transform.SetParent(transform);
        _bullet.transform.localPosition = Vector3.zero;
        _bullet.transform.localRotation = Quaternion.identity;
        _bullet.transform.SetParent(transform.parent.parent);
        _bullet.SetActive(true);
    }
}
