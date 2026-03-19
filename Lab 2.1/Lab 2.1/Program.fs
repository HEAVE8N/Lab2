open System

let getMinDigits (input: string) =
    input.Split(' ')

    |> Array.toList // в первой тоже мейби нахуй
    |> List.filter (fun s -> 
        s <> "" && s |> Seq.forall Char.IsDigit && int s > 0)

    |> List.map (fun s -> 
        s |> Seq.map (fun c -> int c - int '0') |> Seq.min) // может но не хочет, мейби

[<EntryPoint>]
let main _ =
    printf "Введите числа через пробел: "
    let input = Console.ReadLine()

    let result = getMinDigits input

    printfn "Минимальные цифры для каждого числа: %A" result
    0
