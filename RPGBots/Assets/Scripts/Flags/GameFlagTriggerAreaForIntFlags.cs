using UnityEngine;

public class GameFlagTriggerAreaForIntFlags : MonoBehaviour
{
    [SerializeField] IntGameFlag _gameFlag;
    [SerializeField] int _amount = 1;

    public void OnTriggerEnter(Collider other)
    {
        _gameFlag.Modify(_amount);

    }
}
