---------------------------------------------------------------------------------------------------
--===============================================================================================--
-- 
--                        _oo0oo_
--                       o8888888o
--                       88" . "88
--                       (| -_- |)
--                       0\  =  /0
--                     ___/`---'\___
--                   .' \\|     |// '.
--                  / \\|||  :  |||// \
--                 / _||||| -:- |||||- \
--                |   | \\\  -  /// |   |
--                | \_|  ''\---/''  |_/ |
--                \  .-\__  '-'  ___/-. /
--              ___'. .'  /--.--\  `. .'___
--           ."" '<  `.___\_<|>_/___.' >' "".
--          | | :  `- \`.;`\ _ /`;.`/ - ` : | |
--          \  \ `_.   \_ __\ /__ _/   .-` /  /
--      =====`-.____`.___ \_____/___.-`___.-'=====
--                        `=---='
-- 
-- 
--      ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
-- 
--                佛祖保佑         永无BUG
-- 
--  FileName LoginMainView.lua
-- 	Title 
-- 	
--  Description 
-- 	
-- 
--  Created by Mr.Bug on 10/26/2018 10:08 AM.
-- 
--  OpenWay 
--===============================================================================================--
---------------------------------------------------------------------------------------------------

local LuaHelper = LuaHelper
local CSNameSpace = CSNameSpace

local LoginMainView = class(Asset,function(self,item_obj)
    Asset._ctor(self, "welcome.u3d")
    self.item_obj = item_obj
end)

function LoginMainView:on_asset_load(key,asset)
    self.item_obj:register_property_changed(self.databind,self)

    -- local refer = LuaHelper.GetComponent(self.root,CSNameSpace.ReferGameObjects) 
	-- self.refer = refer
end

function LoginMainView:dispose()
    self.item_obj:register_property_changed(self.databind,nil)
    self._base.dispose(self)
 end

function LoginMainView:databind(item_obj,property_name)
    -- if property_name == item_obj.get_npc_map_ack then
    --     self:show_npc_map(item_obj:get_server_source_npc_map())
    -- end
end

return LoginMainView