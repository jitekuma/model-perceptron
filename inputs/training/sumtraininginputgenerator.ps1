
$outputFile = "sum02.csv"
$count = 500000 #50% training

$lines = for ($i = 0; $i -lt $count; $i++) {
    $a = Get-Random -Minimum 0 -Maximum 1000
    $b = Get-Random -Minimum 0 -Maximum 1000

    # Exactly 50% correct and 50% incorrect
    $isCorrect = $i % 2

    if ($isCorrect -eq 1) {
        $c = $a + $b
        $label = 1
    }
    else {
        do {
            $c = Get-Random -Minimum 0 -Maximum 1999
        } while ($c -eq ($a + $b))

        $label = -1
    }

    "$a,$b,$c,$label"
}

$lines | Set-Content -Path $outputFile
