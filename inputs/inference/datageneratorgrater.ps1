
param(
    [int]$Count = 1000,
    [string]$OutputFile = "input.csv"
)

if ($Count -lt 1) {
    throw "Count must be greater than zero."
}

1..$Count | ForEach-Object {
    $a = Get-Random -Minimum 1 -Maximum 1000
    $b = Get-Random -Minimum 1 -Maximum 1000

    "$a,$b"
} | Set-Content -Path $OutputFile
