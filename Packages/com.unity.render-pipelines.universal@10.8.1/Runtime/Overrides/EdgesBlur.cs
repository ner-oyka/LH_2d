using System;

namespace UnityEngine.Rendering.Universal
{
    [Serializable, VolumeComponentMenu("Post-processing/Edges Blur")]
    public sealed class EdgesBlur : VolumeComponent, IPostProcessComponent
    {
        public MinFloatParameter power= new MinFloatParameter(0f, 0f);

        public MinFloatParameter darkness = new MinFloatParameter(0.14f, 0f);

        public MinFloatParameter distance = new MinFloatParameter(1.5f, 0f);

        public MinFloatParameter hardness = new MinFloatParameter(0.3f, 0f);

        public bool IsActive() => power.value > 0f;

        public bool IsTileCompatible() => true;
    }
}
