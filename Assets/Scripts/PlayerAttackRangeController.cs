using UnityEngine;

public class PlayerAttackRangeController : MonoBehaviour
{
    [SerializeField] private Transform reference;
    [SerializeField] private Player player;

    private void Update()
    {
        if (player == null || reference == null) return;

        reference.transform.localScale = Vector3.one * player.ActualWeapon.Range;
    }
}
