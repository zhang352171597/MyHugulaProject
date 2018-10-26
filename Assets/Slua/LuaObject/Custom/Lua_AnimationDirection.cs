using System;
using SLua;
using System.Collections.Generic;
[UnityEngine.Scripting.Preserve]
public class Lua_AnimationDirection : LuaObject {
	static public void reg(IntPtr l) {
		getEnumTable(l,"AnimationDirection");
		addMember(l,0,"Toggle");
		addMember(l,1,"Forward");
		addMember(l,-1,"Reverse");
		LuaDLL.lua_pop(l, 1);
	}
}
