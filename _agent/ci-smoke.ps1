param(
    [switch]$Strict
)

$ErrorActionPreference = "Stop"

$repoRoot = Resolve-Path (Join-Path $PSScriptRoot "..")
$repoRootPath = $repoRoot.Path
$projectPath = Join-Path $repoRootPath "EnemyImbuePresets.csproj"
$testProjectPath = Join-Path $repoRootPath "EnemyImbuePresets.Tests\EnemyImbuePresets.Tests.csproj"

$libsPath = Join-Path (Split-Path $repoRootPath -Parent) "libs"
$requiredDlls = @(
    "ThunderRoad.dll",
    "Assembly-CSharp.dll",
    "Assembly-CSharp-firstpass.dll",
    "UnityEngine.dll",
    "UnityEngine.CoreModule.dll",
    "UnityEngine.IMGUIModule.dll",
    "UnityEngine.TextRenderingModule.dll"
)

$missingDlls = @()
foreach ($dll in $requiredDlls) {
    $dllPath = Join-Path $libsPath $dll
    if (-not (Test-Path $dllPath)) {
        $missingDlls += $dll
    }
}

if ($missingDlls.Count -gt 0) {
    $msg = "[EIP-CI] Missing game libraries in ${libsPath}: $($missingDlls -join ', ')"
    if ($Strict) {
        Write-Error $msg
        exit 1
    }

    Write-Warning $msg
    Write-Warning "[EIP-CI] Skipping Release/Nomad build in non-strict mode."
}
else {
    Write-Host "[EIP-CI] Building Release..."
    dotnet build $projectPath -c Release | Out-Host
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }

    Write-Host "[EIP-CI] Building Nomad..."
    dotnet build $projectPath -c Nomad | Out-Host
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

if (Test-Path $testProjectPath) {
    Write-Host "[EIP-CI] Running tests..."
    dotnet test $testProjectPath -c Release --nologo -v minimal | Out-Host
    if ($LASTEXITCODE -ne 0) {
        exit $LASTEXITCODE
    }
}

Write-Host "[EIP-CI] Smoke checks complete."
exit 0
