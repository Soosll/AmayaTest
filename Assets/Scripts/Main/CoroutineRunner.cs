using System.Collections;
using UnityEngine;

namespace Main
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}