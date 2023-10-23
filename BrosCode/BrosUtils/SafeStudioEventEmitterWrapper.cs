using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SafeStudioEventEmitterWrapper
{
	static public void SafePlaySetParameterByNameWithLabel(this FMODUnity.StudioEventEmitter emitter, string name, string label, bool ignoreseekspeed = false) {
		SafeRun.Run(() => {
			emitter.Play();
			emitter.EventInstance.setParameterByNameWithLabel(name, label, ignoreseekspeed);
		});
	}
}
