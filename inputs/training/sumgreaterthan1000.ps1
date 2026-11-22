
param(
    [int]$Count = 100000,
    [string]$OutputFile = "training04.csv"
)

1..$Count | ForEach-Object {
    $a = Get-Random -Minimum 1 -Maximum 1000
    $b = Get-Random -Minimum 1 -Maximum 1000

    $label = if (($a + $b) -gt 1000) { 1 } else { -1 }

    "$a,$b,$label"
} | Set-Content -Path $OutputFile
