
param(
    [string]$InputFile = "training.csv"
)

$lineNumber = 0
$validCount = 0
$invalidCount = 0

Get-Content $InputFile | ForEach-Object {
    $lineNumber++
    $values = $_ -split ","

    $isValid = $true

    if ($values.Count -ne 3) {
        $isValid = $false
    }
    else {
        $a = 0
        $b = 0
        $label = 0

        if (-not [int]::TryParse($values[0], [ref]$a) -or
            -not [int]::TryParse($values[1], [ref]$b) -or
            -not [int]::TryParse($values[2], [ref]$label)) {
            $isValid = $false
        }
        elseif ($a -lt 1 -or $a -ge 1000 -or
                $b -lt 1 -or $b -ge 1000) {
            $isValid = $false
        }
        else {
            $expected = if (($a + $b) -gt 1000) { 1 } else { -1 }

            if ($label -ne $expected) {
                $isValid = $false
            }
        }
    }

    if ($isValid) {
        $validCount++
    }
    else {
        $invalidCount++
        Write-Host "Invalid line $lineNumber : $_" -ForegroundColor Red
    }
}

Write-Host "`nValidation Summary"
Write-Host "Total lines  : $lineNumber"
Write-Host "Valid lines  : $validCount"
Write-Host "Invalid lines: $invalidCount"

if ($invalidCount -eq 0) {
    Write-Host "Validation PASSED" -ForegroundColor Green
}
else {
    Write-Host "Validation FAILED" -ForegroundColor Red
    exit 1
}
