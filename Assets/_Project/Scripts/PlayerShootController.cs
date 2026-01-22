using UnityEngine;

public class PlayerShootController : MonoBehaviour
{
    private Camera _cam;

    [Header ("Turret")]
    [SerializeField] private Transform _towerTransform;
    [SerializeField] private float _towerRotationSpeed;

    [Header("Aim")]
    [SerializeField] private Transform _aimTransform;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        UpdateMouseAim();
    }

    private void FixedUpdate()
    {
        ApplyTowerRotation();
    }

    private void ApplyTowerRotation()
    {
        Vector3 rotation = _aimTransform.position - _towerTransform.position;
        rotation.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(rotation);
        _towerTransform.rotation = Quaternion.RotateTowards(_towerTransform.rotation, targetRotation, _towerRotationSpeed);
    }

    private void UpdateMouseAim()
    {
        Ray aim = _cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(aim, out hit, Mathf.Infinity))
        {
            float fixedY = _aimTransform.position.y;
            _aimTransform.position = new Vector3(hit.point.x, fixedY, hit.point.z);
        }
    }

    public interface IDamageable
    {
        void Damage(int damage);
    }
}
