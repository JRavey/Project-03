using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private BallsData _data;

    private void Start()
    {
        // spawn in world
        Instantiate(_data.Visuals, transform.position,
            Quaternion.identity);
        // print info about weapon
        Debug.Log(_data.Name + " deals: " + _data.Damage);
    }
}
