use std::io;

macro_rules! parse_input {
    ($x:expr, $t:ident) => {
        $x.trim().parse::<$t>().unwrap()
    };
}

/**
 * 6 Degrees of Kevin Bacon!
 **/
pub fn six_degrees() {
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let actor_name = input_line.trim_matches('\n').to_string();
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let n = parse_input!(input_line, i32);
    for i in 0..n as usize {
        let mut input_line = String::new();
        io::stdin().read_line(&mut input_line).unwrap();
        let movie_cast = input_line.trim_matches('\n').to_string();
    }

    // Write an answer using println!("message...");
    // To debug: eprintln!("Debug message...");

    println!("N degrees to Kevin Bacon");
}