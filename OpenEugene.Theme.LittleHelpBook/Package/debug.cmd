XCOPY "..\Client\bin\Debug\net8.0\OpenEugene.Theme.LittleHelpBook.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\OpenEugene.Theme.LittleHelpBook.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\MudBlazor.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y

msbuild /p:Configuration=Debug /p:OutputPath=..\Client\wwwroot\_content
XCOPY "..\Client\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
