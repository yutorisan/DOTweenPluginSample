using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityUtility;

public class DOTweenAngle : MonoBehaviour
{
    //90°から360°まで回転移動するTween
    private TweenerCore<Angle, Angle, AngleOptions> GetBaseTween(float duration) =>
        DOTween.To(AnglePlugin.Instance,
                   () => Angle.FromDegree(90),
                   ang => MoveOnCircumference(ang),
                   Angle.Round,
                   duration)
               .SetEase(Ease.Linear)
               .SetDelay(0.5f);

    //角度を指定すると半径1のXY円周上の座標に移動する
    private void MoveOnCircumference(Angle angle) =>
        this.transform.position = new Vector3(Mathf.Sin(angle.TotalRadian),
                                              Mathf.Cos(angle.TotalRadian),
                                              0);

    [ContextMenu(nameof(Basic))]
    private void Basic()
    {
        //90°から360°まで
        GetBaseTween(1f);
    }

    [ContextMenu(nameof(Relative))]
    private void Relative()
    {
        //90°から450°まで一周
        GetBaseTween(1f).SetRelative();
    }

    [ContextMenu(nameof(From))]
    private void From()
    {
        //360°から90°まで
        GetBaseTween(1f).From();
    }

    [ContextMenu(nameof(From180))]
    private void From180()
    {
        //180°から360°まで
        GetBaseTween(1f).From(Angle.FromDegree(180));
    }

    [ContextMenu(nameof(SpeedBased))]
    private void SpeedBased()
    {
        //90°/sの速さで90°から360°まで
        GetBaseTween(90).SetSpeedBased(AngularVelocityUnit.DegreePerSecond);
    }

    [ContextMenu(nameof(AlwaysForward))]
    private void AlwaysForward()
    {
        //0°から90°まで
        GetBaseTween(1f).From().SetOptions(AngleTweenDirection.Forward);
    }
}
