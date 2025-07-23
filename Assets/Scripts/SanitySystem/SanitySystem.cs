using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SanitySystem
{
    private Volume globalVolume;
    private DepthOfField depthOfField;
    private Vignette vignette;
    private ColorAdjustments colorAdjustments;


    public SanitySystem(Volume globalVolume)
    {
        this.globalVolume = globalVolume;
    }

    public void RemoveDepthOfField()
    {
        globalVolume.profile.TryGet(out depthOfField);
        depthOfField.active = false;
    }

    public void RemoveVignette()
    {
        globalVolume.profile.TryGet(out vignette);
        vignette.active = false;
    }

    public void RemoveColorAdjustments()
    {
        globalVolume.profile.TryGet(out colorAdjustments);
        colorAdjustments.active = false;
    }

}
