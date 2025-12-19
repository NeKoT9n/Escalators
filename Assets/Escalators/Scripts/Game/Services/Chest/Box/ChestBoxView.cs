using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Assets.Escalators.Scripts.Game.Services.Chest.Box
{
    public class ChestBoxView : MonoBehaviour 
    {
        public async UniTask Appear()
        {
            gameObject.SetActive(true);

            transform.localScale = Vector3.zero;

            Sequence chestSequence = DOTween.Sequence();

            chestSequence
                .Append(transform.DOScale(Vector3.one, 1).SetEase(Ease.OutBack))       
                .Join(transform.DOJump(transform.position, 3, 1, 1.5f).SetEase(Ease.Linear))
                .Join(transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.FastBeyond360)
            .SetEase(Ease.InOutQuad));

            await chestSequence.ToUniTask();
            await UniTask.WaitForSeconds(0.3f);

            transform.DOShakeScale(0.2f, 0.2f);

        }

    }

}
