using UnityEngine;

public class ShieldPower : MonoBehaviour
{
    public float duration = 5f;
    private bool active = false;

    public bool IsActive()
    {
        return active;
    }

    public void Activate()
    {
        if (active) return; // evita spam

        active = true;
        Debug.Log("🛡️ Escudo ativado!");

        Invoke(nameof(Deactivate), duration);
    }

    void Deactivate()
    {
        active = false;
        Debug.Log("❌ Escudo acabou!");
    }
}