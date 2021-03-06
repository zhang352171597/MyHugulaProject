﻿using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Hugula_LogicHelper : LuaObject {
	[SLua.MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	[UnityEngine.Scripting.Preserve]
	static public int OnAssetsLoad_s(IntPtr l) {
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
			Hugula.Loader.CRequest a1;
			checkType(l,1,out a1);
			SLua.LuaTable a2;
			checkType(l,2,out a2);
			Hugula.LogicHelper.OnAssetsLoad(a1,a2);
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
		getTypeTable(l,"Hugula.LogicHelper");
		addMember(l,OnAssetsLoad_s);
		createTypeMetatable(l,null, typeof(Hugula.LogicHelper));
	}
}
