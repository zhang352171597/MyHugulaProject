//
//                       _oo0oo_
//                      o8888888o
//                      88" . "88
//                      (| -_- |)
//                      0\  =  /0
//                    ___/`---'\___
//                  .' \\|     |// '.
//                 / \\|||  :  |||// \
//                / _||||| -:- |||||- \
//               |   | \\\  -  /// |   |
//               | \_|  ''\---/''  |_/ |
//               \  .-\__  '-'  ___/-. /
//             ___'. .'  /--.--\  `. .'___
//          ."" '<  `.___\_<|>_/___.' >' "".
//         | | :  `- \`.;`\ _ /`;.`/ - ` : | |
//         \  \ `_.   \_ __\ /__ _/   .-` /  /
//     =====`-.____`.___ \_____/___.-`___.-'=====
//                       `=---='
//
//
//     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//
//               佛祖保佑         永无BUG
//
//
//  LuaCreate#FILEEXTENSION#
//	Title:
//	
//  Description:
//	
//
//  Created by #AUTHOR# on #CREATIONDATE#.
//
//

using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using UnityEditor.ProjectWindowCallback;
using System.Text.RegularExpressions;
 
public class LuaCreater
{
    [MenuItem("Assets/Create/Lua/View", false, 80)]
    public static void CreatNewLuaView()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/New Lua.lua",
        null,
       "Assets/Lua/MyGame/Until/LuaViewTemplate.lua");
    }

    [MenuItem("Assets/Create/Lua/Model", false, 80)]
    public static void CreatNewLuaModel()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
        ScriptableObject.CreateInstance<MyDoCreateScriptAsset>(),
        GetSelectedPathOrFallback() + "/New Lua.lua",
        null,
       "Assets/Lua/MyGame/Until/LuaModelTemplate.lua");
    }
 
    public static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }
}
 
class MyDoCreateScriptAsset : EndNameEditAction
{
    public override void Action(int instanceId, string pathName, string resourceFile)
    {
        UnityEngine.Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
        ProjectWindowUtil.ShowCreatedAsset(o);
    }
 
    internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
    {
        string fullPath = Path.GetFullPath(pathName);
        StreamReader streamReader = new StreamReader(resourceFile);
        string text = streamReader.ReadToEnd();
        streamReader.Close();
        string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
        text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
        var time = System.DateTime.Now;
        text = Regex.Replace(text , "#CREATIONDATE#" , time.ToString("g"));
        text = Regex.Replace(text , "#AUTHOR#" , "Mr.Bug");
        
        //string text2 = Regex.Replace(fileNameWithoutExtension, " ", string.Empty);
        //text = Regex.Replace(text, "#SCRIPTNAME#", text2);
        //if (char.IsUpper(text2, 0))
        //{
        //    text2 = char.ToLower(text2[0]) + text2.Substring(1);
        //    text = Regex.Replace(text, "#SCRIPTNAME_LOWER#", text2);
        //}
        //else
        //{
        //    text2 = "my" + char.ToUpper(text2[0]) + text2.Substring(1);
        //    text = Regex.Replace(text, "#SCRIPTNAME_LOWER#", text2);
        //}
        bool encoderShouldEmitUTF8Identifier = true;
        bool throwOnInvalidBytes = false;
        UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
        bool append = false;
        StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
        streamWriter.Write(text);
        streamWriter.Close();
        AssetDatabase.ImportAsset(pathName);
        return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
    }
 
}
