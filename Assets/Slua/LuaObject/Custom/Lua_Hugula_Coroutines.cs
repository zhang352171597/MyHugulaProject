using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_Hugula_Coroutines : LuaObject {
	[UnityEngine.Scripting.Preserve]
	static public void reg(IntPtr l) {
		getTypeTable(l,"Hugula.Coroutines");
		createTypeMetatable(l,null, typeof(Hugula.Coroutines),typeof(UnityEngine.MonoBehaviour));
	}
}
