using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArki.FreeParam.Sample {

    public class SampleFreeParam : MonoBehaviour {

        void Awake() {
            FreeParamCore.Initialize();

            FreeParamCore.TryGetBool("b", out bool b);
        }
    }

}
