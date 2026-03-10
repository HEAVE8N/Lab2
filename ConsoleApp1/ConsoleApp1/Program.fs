open System

// Задание 1
let rec findM n numMin =
    if 
        n = 0 
    then
        if numMin = 9 then 0 else numMin

    else
        let lastD = abs (n % 10)
        let newMin = if lastD < numMin then lastD else numMin
        findM (n / 10) newMin

// Задание 2
let cont (digit: int) (n: int) =
    let digitChar = (string digit)[0]
    string (abs n) |> String.exists (fun c -> c = digitChar)

[<EntryPoint>]
let main argv =
    let rec loop () =
        printfn "\nВыберите задание:"
        printfn "1 - Найти минимальные цифры в списке чисел"
        printfn "2 - Посчитать числа, содержащие заданную цифру"
        printfn "0 - Выход"
        printf "Ваш выбор: "

        match Console.ReadLine() with

        | "1" ->
            printfn "Введите числа через пробел:"
            let input = Console.ReadLine()
            let numbers =
                input.Split([| ' ' |],  
                    StringSplitOptions.RemoveEmptyEntries)
                |> List.ofArray

                |> List.map int

            let result = numbers |> List.map 
                                    (fun n -> if n = 0 
                                              then 0 
                                              else findM n 9)
            printfn "Минимальные цифры для каждого числа: %A" 
                result
            loop ()


        | "2" ->
            printf "Введите числа через пробел: "
            let input = Console.ReadLine()
            let numbers =
                input.Split([| ' ' |], 
                    StringSplitOptions.RemoveEmptyEntries)
                |> Array.map int

                |> Array.toList

            printf "Какую цифру ищем? "
            match Int32.TryParse(Console.ReadLine()) with
            | true, targetDigit ->
                let filt = numbers 
                        |> List.filter (cont targetDigit)
                printfn "\nЧисла, где есть цифра %d: %A"
                    targetDigit filt
                printfn "Количество таких элементов: %d" 
                    filt.Length

            | _ -> 
                printfn "Ошибка: введите корректную цифру."
            loop ()

        | "0" ->
            printfn "Программа завершена."
            Console.ReadLine() |> ignore

        | _ ->
            printfn "Некорректный выбор. Попробуйте снова."
            loop ()

    loop ()
    0
