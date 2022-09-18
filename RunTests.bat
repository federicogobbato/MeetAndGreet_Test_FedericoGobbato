@ECHO OFF
ECHO ___________________________________________________
set /P PathUnity=Insert Unity.exe path? 
ECHO ___________________________________________________
:start
ECHO Edit Mode -- 1
ECHO PlayMode -- 2
set /P TestMode= Which Mode? 
ECHO ___________________________________________________
if %TestMode%==1 %PathUnity% -runTests -projectPath "./" -testResults ./testResultsEditMode.xml -testPlatform EditMode
if %TestMode%==2 %PathUnity% -runTests -projectPath "./" -testResults ./testResultsPlayMode.xml -testPlatform PlayMode
ECHO ___________________________________________________
goto start
