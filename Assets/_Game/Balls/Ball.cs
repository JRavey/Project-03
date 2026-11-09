using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public BallsData _data;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = _data.Visuals;

        // spawn in world
        Instantiate(_data.Visuals, transform.position,
            Quaternion.identity);
        // print info about weapon
        Debug.Log(_data.Name + " deals: " + _data.Damage);
    }
}
