use std::io;

// trait Sorter {
//     fn sort(&self) -> String;
// }

fn get_input() -> String{
    println!("Add one or more numbers to the vector, comma separated.");
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let inputs: String = input_line.chars().filter(|c| !c.is_whitespace()).collect();
    return inputs;
}

pub fn sort(){
    println!("Choose your sorter:");
    println!("1: Default Sorter");
    println!("2: Liniar number sorter");
    println!("3: Generic sorter (not implemented)");

    let choice = get_input();
    match choice.as_str() {
        "1" => {
            let mut numbers: Vec<i32> = vec![];
            let inputs = get_input();
            for i in inputs.split(','){
                if let Ok(number) = i.trim().parse::<i32>(){
                    numbers.push(number);
                }
            }
            numbers.sort();
            print_results(numbers);
        }
        "2" =>{
            let inputs = get_input();
            let numbers = simple_sorting(inputs);
            print_results(numbers);
        }
        _ => { // Default case for any other input
            println!("Invalid choice.");
        }
    }
}

fn print_results(numbers: Vec<i32>){
    for i in 0..numbers.len(){
        if i == numbers.len()-1{
            print!("{}", numbers[i]);
            continue;
        }
        print!("{}, ", numbers[i]);
    }
}

fn simple_sorting(inputs: String) -> Vec<i32>{
    // define a vector of integers
    let mut numbers: Vec<i32> = vec![];
    for i in inputs.split(','){
        if let Ok(number) = i.trim().parse::<i32>(){
            numbers.push(number);
        }
    }
    for i in 0..numbers.len()-1{
        for j in i+1..numbers.len(){
            if numbers[j] < numbers[i] {
                let temp = numbers[j];
                numbers[j] = numbers[i];
                numbers[i] = temp;
            }
        }
    
    }
    return numbers;
}