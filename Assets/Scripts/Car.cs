using UnityEngine;
using DG.Tweening;

public class Car : MonoBehaviour
{
    public GameObject vfxDestroy;

    public void PlayVfx()
    {
        GameObject vfx = Instantiate(vfxDestroy, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);

        transform.DOScale(0, 1f);
    }
}
