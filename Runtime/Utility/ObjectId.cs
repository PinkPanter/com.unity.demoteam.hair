using UnityEngine;

namespace Unity.DemoTeam.Hair
{
	public static class ObjectId
	{
		/// <summary>
		/// Object.GetInstanceID() is an error from Unity 6.5 on. 
		/// On 6.4+ it is the low 32 bits of the EntityId, so the sign survives
		/// </summary>
		/// <param name="obj">Source object</param>
		/// <returns>Negative id meaning 'not persistent'</returns>
		public static int Of(Object obj)
		{
#if UNITY_6000_4_OR_NEWER
			return unchecked((int)EntityId.ToULong(obj.GetEntityId()));
#else
			return obj.GetInstanceID();
#endif
		}
	}

#if UNITY_2023_2_OR_NEWER
	public static class RenderParamsUtility
	{
		/// <summary>
		/// RenderParams.instanceID became entityId in 6.3
		/// </summary>
		/// <param name="rparams">Render params to set owner</param>
		/// <param name="obj">Owner object</param>
		public static void SetOwner(ref RenderParams rparams, Object owner)
		{
#if UNITY_6000_4_OR_NEWER
			rparams.entityId = owner.GetEntityId();
#elif UNITY_6000_3_OR_NEWER
			rparams.entityId = owner.GetInstanceID();
#else
			rparams.instanceID = owner.GetInstanceID();
#endif
		}
	}
#endif
}
