using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONArrow : CONEntity
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public void Play(Vector3 target, Action onEnd)
    {
        StartCoroutine(PlayEffect(target, onEnd));
    }

    private IEnumerator PlayEffect(Vector3 target, Action onEndEffect)
    {
        Vector3 start = transform.position;

        Vector3 p0 = start;

        Vector3 prevPoint = start;
        Vector3 dir = Vector3.zero;

        transform.rotation = Quaternion.identity;

        float angle = 0f;
        float t = 0f;

        while (t < 1f)
        {
            yield return null;

            transform.position = QuadraticBezierPoint(t, start, p0, target);

            dir = transform.position - prevPoint;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            prevPoint = transform.position;

            t += Time.deltaTime * 3f;
        }

        onEndEffect?.Invoke();

        SetActive(false);

        yield return null;
    }


    private Vector3 QuadraticBezierPoint(float t, Vector3 start, Vector3 p1, Vector3 end)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * start;
        p += 2 * u * t * p1;
        p += tt * end;

        return p;
    }
}
