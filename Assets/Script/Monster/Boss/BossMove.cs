using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    [SerializeField] protected float minCamPos = -16f;
    [SerializeField] protected float maxCamPos = 16f;
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.right;
    protected virtual void ResetValue()
    {
        this.moveSpeed = 1f;
    }

    protected virtual void OnEnable()
    {
        
        this.GetFlyDirection();
    }

    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = BossCtrl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;

        camPos.x += Random.Range(this.minCamPos, this.maxCamPos);
        camPos.z += Random.Range(this.minCamPos, this.maxCamPos);

        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float roz_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, roz_z);

        Debug.DrawLine(objPos, objPos + diff * 7, Color.red, Mathf.Infinity);
    }
}
