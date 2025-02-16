use std::io;

macro_rules! parse_input {
    ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
}

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
pub fn island_escape() {
    let mut input_line = String::new();
    let mut lines: Vec<i32> = Vec::new();
    io::stdin().read_line(&mut input_line).unwrap();

    let n = parse_input!(input_line, i32);
    for i in 0..n as usize {
        let mut inputs = String::new();
        io::stdin().read_line(&mut inputs).unwrap();

        lines.extend(inputs.split_whitespace().map(|j| parse_input!(j, i32)));
    }



    // Write an answer using println!("message...");
    // To debug: eprintln!("Debug message...");

    println!("maybe");
}
