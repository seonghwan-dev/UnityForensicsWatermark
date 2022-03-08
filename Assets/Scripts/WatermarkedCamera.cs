﻿using UnityEngine;

namespace FW
{
#if UNITY_EDITOR
	[RequireComponent(typeof(Camera))]
#endif
	public sealed class WatermarkedCamera : MonoBehaviour
	{
		public Watermark watermark;
		
		private Material _material;

		private void Awake()
		{
			var shader = Shader.Find("Forensics/WatermarkCamera");
			if (shader == null)
			{
				enabled = false;
				Debug.LogWarning("Shader <i>Forensics/WatermarkCamera</i> not found. Watermark disabled.");
				return;
			}
			
			_material = new Material(shader);
		}

		private void OnRenderImage(RenderTexture src, RenderTexture dest)
		{
			BeforeBlit(src);
			Graphics.Blit(src, dest, _material);
		}

		private void BeforeBlit(RenderTexture src)
		{
		}
	}
}