XCOPY "..\Client\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Shared\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Shared\bin\Debug\net8.0\OpenEugene.Module.LittleHelpBook.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y

msbuild /t:ExtractContentFiles /p:Configuration=Release /p:OutputPath=..\Server\wwwroot\_content
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
XCOPY "..\Client\bin\Debug\net8.0\MudBlazor.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y

