using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Mewlist.MassiveClouds
{
    [Serializable]
    public class MassiveCloudsVolumetricShadowPass : IMassiveCloudsPass<MassiveCloudsStylizedCloud>
    {
        [Range(1 / 16.0f, 1f)] [SerializeField]
        private float volumetricShadowResolution = 0.5f;

        private RenderTextureDesc[] volumetricShadowRtDesc = new RenderTextureDesc[2];
        private RenderTexture[] volumetricShadowRT = new RenderTexture[2];

        private float cycle = 0f;

        public float VolumetricShadowResolution { get { return volumetricShadowResolution; } }
        
        private DistanceComparer distanceComparer;
        private List<int> sortedIndex = new List<int>();

        public void Update(MassiveCloudsStylizedCloud context)
        {
            // Sorted Index
            if (sortedIndex.Count != context.Profiles.Count)
            {
                sortedIndex.Clear();
                sortedIndex.AddRange(Enumerable.Range(0, context.Profiles.Count));
            }
        }
        
        public void BuildCommandBuffer(MassiveCloudsStylizedCloud context, Camera targetCamera, CommandBuffer commandBuffer, FlippingRenderTextures renderTextures)
        {
            if (!context.HasVolumetricShadow) return;

            if (distanceComparer == null) distanceComparer = new DistanceComparer(context);
            distanceComparer.SetTargetCamera(targetCamera);
            sortedIndex.Sort(distanceComparer);

            var eyeIndex = 0;
            switch (targetCamera.stereoActiveEye)
            {
                case Camera.MonoOrStereoscopicEye.Left:
                    break;
                case Camera.MonoOrStereoscopicEye.Right:
                    eyeIndex = 1;
                    break;
                case Camera.MonoOrStereoscopicEye.Mono:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            cycle += 0.2f;
            if (cycle >= 1f) cycle = 0f;

            var rtW = Mathf.RoundToInt(renderTextures.ScreenWidth * volumetricShadowResolution);
            var rtH = Mathf.RoundToInt(renderTextures.ScreenHeight * volumetricShadowResolution);

            var rtInfo = new RenderTextureDesc(
                rtW,
                rtH);
            if (!volumetricShadowRtDesc[eyeIndex].Equals(rtInfo))
            {
                if (volumetricShadowRT[eyeIndex] != null) volumetricShadowRT[eyeIndex].Release();
                volumetricShadowRtDesc[eyeIndex] = rtInfo;
                volumetricShadowRT[eyeIndex] = renderTextures.CreateRenderTexture(volumetricShadowRtDesc[eyeIndex]);
            }
            
            var tempId = Shader.PropertyToID("_MassiveClouds_Empty");
            commandBuffer.GetTemporaryRT(tempId, 8, 8,
                0, FilterMode.Point, RenderTextureFormat.Default);
            var fullId = Shader.PropertyToID("_MassiveClouds_Full");
            commandBuffer.GetTemporaryRT(fullId, targetCamera.pixelWidth, targetCamera.pixelHeight, 0,
                FilterMode.Point, RenderTextureFormat.Default);

            // volumetric shadow
            for (var i = 0; i < context.Profiles.Count; i++)
            {
                int index = sortedIndex[i];
                if (context.Profiles[index] == null) continue;
                if (!context.Parameters[index].VolumetricShadow) continue;
                commandBuffer.SetGlobalTexture("_ScreenTexture", renderTextures.From);
                commandBuffer.SetGlobalTexture("_CloudTexture", renderTextures.LowResolutionTmpId);
                var m = context.Mixers[index];
                var material = m.Material.VolumetricShadowMaterial;
                commandBuffer.Blit(tempId, volumetricShadowRT[eyeIndex], material);
                commandBuffer.Blit(volumetricShadowRT[eyeIndex], fullId, material);
                commandBuffer.Blit(fullId, renderTextures.To, m.Material.VolumetricShadowMixMaterial);

                renderTextures.Flip();
            }

            commandBuffer.ReleaseTemporaryRT(tempId);
            commandBuffer.ReleaseTemporaryRT(fullId);
        }

        public void Clear()
        {
            if (volumetricShadowRT[0] != null) volumetricShadowRT[0].Release();
            if (volumetricShadowRT[1] != null) volumetricShadowRT[1].Release();

            volumetricShadowRT[0] = null;
            volumetricShadowRT[1] = null;
            volumetricShadowRtDesc[0] = default(RenderTextureDesc);
            volumetricShadowRtDesc[1] = default(RenderTextureDesc);
        }
    }
}