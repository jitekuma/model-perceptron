
$outputFile = "inference01-1.csv"
$count = 1000

$lines = for ($i = 0; $i -lt $count; $i++) {
    $a = Get-Random -Minimum 0 -Maximum 1000
    $b = Get-Random -Minimum 0 -Maximum 1000

    if ($i % 2 -eq 0) {
        # Correct sum
        $c = $a + $b
    }
    else {
        # Random incorrect sum
        do {
            $c = Get-Random -Minimum 0 -Maximum 1999
        } while ($c -eq ($a + $b))
    }

    "$a,$b,$c"
}

$lines | Set-Content -Path $outputFile
