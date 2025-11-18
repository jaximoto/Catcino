using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour
{
    public void AppyItemEffects(ItemSO itemSO)
    {
        if (itemSO.luckBonus > 0)
            StatManager.instance.UpdateLuck(itemSO.luckBonus);
        if (itemSO.cautionBonus > 0)
            StatManager.instance.UpdateCaution(itemSO.cautionBonus);
        if (itemSO.perceptionBonus > 0)
            StatManager.instance.UpdatePerception(itemSO.perceptionBonus);
        if (itemSO.duration > 0)
            StartCoroutine(EffectTimer(itemSO, itemSO.duration));



    }
    private IEnumerator EffectTimer(ItemSO itemSO, int duration)
    {
        yield return new WaitForSeconds(duration);
        if (itemSO.luckBonus > 0)
            StatManager.instance.UpdateLuck(-itemSO.luckBonus);
        if (itemSO.cautionBonus > 0)
            StatManager.instance.UpdateCaution(-itemSO.cautionBonus);
        if (itemSO.perceptionBonus > 0)
            StatManager.instance.UpdatePerception(-itemSO.perceptionBonus);
    }
}
