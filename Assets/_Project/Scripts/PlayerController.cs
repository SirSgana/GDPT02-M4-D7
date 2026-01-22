using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Movement Data")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotSpeed;

    private float _v;
    private float _h;
    private Vector3 _dir;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckInputs();
    }

    private void CheckInputs()
    {
        //Input di movimento
        _v = Input.GetAxis("Vertical");
        _h = Input.GetAxis("Horizontal");

        if (_v < 0)
        {
            _h = -Input.GetAxis("Horizontal");
        }

        _dir = new Vector3(_h, 0f, _v).normalized;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    private void ApplyMovement()
    {
        //Movimenti avanti ed indietro
        Vector3 movement = transform.forward * _moveSpeed * _v * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);
    }

    private void ApplyRotation()
    {
        Vector3 rotation = new Vector3(0, _h * _rotSpeed, 0);
        transform.Rotate(rotation * Time.fixedDeltaTime);
    }


    //Parte dell'esercizio che chiede un movimento WASD

    //private void ApplyMovement()
    //{
    //    _rb.MovePosition(_rb.position + _dir * _moveSpeed * Time.fixedDeltaTime);
    //}

    //private void ApplyRotation(Vector3 _dir)
    //{
    //    if (_dir != Vector3.zero)
    //    {
    //        Quaternion toRotation = Quaternion.LookRotation(_dir, Vector3.up);
    //        Quaternion newRotation = Quaternion.RotateTowards(_rb.rotation, toRotation, _rotSpeed * Time.fixedDeltaTime);
    //        _rb.MoveRotation(newRotation);
    //    }
    //}

}