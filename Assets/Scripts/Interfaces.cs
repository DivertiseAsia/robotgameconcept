using UnityEngine;
using System.Collections;

namespace Robot
{

    public interface ITargetReceivable
    {
        void SetTarget(Vector3 position, PointerController controller);
    }
}