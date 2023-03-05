using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : MonoBehaviour
{
    private static BossCtrl instance;
    public static BossCtrl Instance { get => instance; }

    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera { get => mainCamera; }

    protected virtual void Awake()
    {
        
        if (BossCtrl.instance != null) Debug.LogError("Only 1 Gamemanager allow ");
        BossCtrl.instance = this;
    }
    protected virtual void LoadComponents()
    {
        
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = BossCtrl.FindObjectOfType<Camera>();
        Debug.Log(transform.name + "LoadCamera", gameObject);
    }
}
