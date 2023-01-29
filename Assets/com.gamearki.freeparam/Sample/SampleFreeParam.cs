using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArki.FreeParam.Sample {

    public class SampleFreeParam : MonoBehaviour {

        void Awake() {
            string src = "true ";
            bool has = bool.TryParse(src, out bool b);
            Debug.Log(b);
        }
    }

}
