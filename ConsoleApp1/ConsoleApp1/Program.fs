open System

let getResult (input: string) (digit: char) =
    input.Split(' ')

    |> Array.toList
    |> List.filter (fun s -> s <> "")
    |> List.filter (fun s -> 
        s |> Seq.forall Char.IsDigit && s.Contains(digit)) // мейби хуйня, сказали оставить
    |> List.fold (fun acc _ -> acc + 1) 0

[<EntryPoint>]
let main _ =
    printf "Введите числа через пробел: "
    let input = Console.ReadLine()
    
    printf "Какую цифру ищем: "
    let digit = Console.ReadKey().KeyChar
    printfn ""

    let result = getResult input digit

    printfn "числа где есть заданное число : %d" result
    0
