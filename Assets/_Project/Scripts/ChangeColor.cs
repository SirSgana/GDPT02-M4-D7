using UnityEngine;

public class ChangeColor : MonoBehaviour, IDamageable
{
    private MeshRenderer _renderer;

    private void Start()
    {
        if (_renderer == null)
        {
            _renderer = GetComponent<MeshRenderer>();
        }

    }

    public void Damage(int damage)
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value);

        _renderer.material.color = randomColor;
    }
}
