set CURRENT_ROOT=%~dp0
set PAN=%~d0
%PAN%
cd %CURRENT_ROOT%
cd ..\..\
set PROJECT_ROOT=%cd%
set UNITY_PATH="C:\Program Files\Unity\Editor\Unity.exe"
echo %PROJECT_ROOT%

set slua_path=%PROJECT_ROOT%\Assets\Slua\LuaObject
echo %slua_path%
rd /s /q %slua_path%
echo "del slua sccuess "

set StreamingPath=%PROJECT_ROOT%\Assets\StreamingAssets
rd /s /q %StreamingPath%
echo "del StreamingPath sccuess "
echo %UNITY_PATH%

%UNITY_PATH% -projectPath %PROJECT_ROOT% -quit -batchmode -executeMethod ProjectBuild.ScriptingDefineSymbols defineSymbols:HUGULA_NO_LOG,HUGULA_SPLITE_ASSETBUNDLE,HUGULA_APPEND_CRC,HUGULA_RELEASE  -logFile $stdout
echo "scriptingDefineSymbols  sccuess"

%UNITY_PATH% -projectPath %PROJECT_ROOT% -quit -batchmode -executeMethod ProjectBuild.BuildSlua -logFile $stdout
echo "slua make sccuess"
%UNITY_PATH% -projectPath %PROJECT_ROOT% -quit -batchmode -executeMethod ProjectBuild.ExportRes -logFile $stdout
echo "ExportRes  sccuess"
%UNITY_PATH% -projectPath %PROJECT_ROOT% -quit -batchmode -executeMethod ProjectBuild.BuildForWindows -logFile $stdout
echo "windows build sccuess"

pause