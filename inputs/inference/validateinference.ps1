
param(
    [Parameter(Mandatory = $true)]
    [string]$InputFile
)

$correct = 0
$wrong = 0

Get-Content $InputFile | ForEach-Object {
    $numbers = $_.Split(',')

    $a = [int]$numbers[0]
    $b = [int]$numbers[1]
    $c = [int]$numbers[2]
    $label = [int]$numbers[3]

    $sum = $a + $b

    if (($c -eq $sum -and $label -eq 1) -or
        ($c -ne $sum -and $label -eq -1)) {
        $correct++
    }
    else {
        $wrong++
		Write-Host "Wrong: $a,$b,$c,$label (Expected: $(if ($c -eq $sum) { 1 } else { -1 }))"
    }
}

Write-Host "Correct: $correct"
Write-Host "Wrong:   $wrong"
