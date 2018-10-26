using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Hugula_Utils_LightHelper : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int SetLightMapSetting_s(IntPtr l) {
		try {
			#if DEBUG
			var method = System.Reflection.MethodBase.GetCurrentMethod();
			string methodName = GetMethodName(method);
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.BeginSample(methodName);
			#else
			UnityEngine.Profiler.BeginSample(methodName);
			#endif
			#endif
			System.UInt16 a1;
			checkType(l,1,out a1);
			UnityEngine.Texture2D a2;
			checkType(l,2,out a2);
			UnityEngine.Texture2D a3;
			checkType(l,3,out a3);
			Hugula.Utils.LightHelper.SetLightMapSetting(a1,a2,a3);
			pushValue(l,true);
			return 1;
		}
		catch(Exception e) {
			return error(l,e);
		}
		#if DEBUG
		finally {
			#if UNITY_5_5_OR_NEWER
			UnityEngine.Profiling.Profiler.EndSample();
			#else
			UnityEngine.Profiler.EndSample();
			#endif
		}
		#endif
	}
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Hugula.Utils.LightHelper");
		addMember(l,SetLightMapSetting_s);
		createTypeMetatable(l,null, typeof(Hugula.Utils.LightHelper));
	}
}
