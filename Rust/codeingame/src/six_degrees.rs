use std::io;
use std::collections::{VecDeque, HashSet};

type Matrix = Vec<Vec<Vec<String>>>;

macro_rules! parse_input {
    ($x:expr, $t:ident) => {
        $x.trim().parse::<$t>().unwrap()
    };
}

fn initialize_matrix(n: usize, m: usize) -> Matrix {
    // Initialize a matrix of size n x m with empty lists of strings
    vec![vec![Vec::new(); m]; n]
}

fn bfs_search(matrix: &Matrix, target: &str) -> Option<usize> {
    let n = matrix.len();
    let m = matrix[0].len();

    // Queue for BFS: stores (row, col, steps)
    let mut queue = VecDeque::new();
    // Visited set to avoid revisiting cells
    let mut visited = HashSet::new();

    // Initialize the queue with all cells that contain the target string
    for i in 0..n {
        for j in 0..m {
            if matrix[i][j].contains(&target.to_string()) {
                queue.push_back((i, j, 0));
                visited.insert((i, j));
            }
        }
    }

    // Directions for moving in the matrix (up, down, left, right)
    let directions = [(-1, 0), (1, 0), (0, -1), (0, 1)];

    while let Some((i, j, steps)) = queue.pop_front() {
        // Check if the current cell contains the target string
        if matrix[i][j].contains(&target.to_string()) {
            return Some(steps);
        }

        // Explore neighbors
        for (di, dj) in &directions {
            let ni = i as isize + di;
            let nj = j as isize + dj;

            // Check if the neighbor is within bounds and not visited
            if ni >= 0 && ni < n as isize && nj >= 0 && nj < m as isize {
                let ni = ni as usize;
                let nj = nj as usize;

                if !visited.contains(&(ni, nj)) {
                    visited.insert((ni, nj));
                    queue.push_back((ni, nj, steps + 1));
                }
            }
        }
    }

    // If the target string is not found
    None
}

fn execute() {
    // Example usage
    let n = 3;
    let m = 3;
    let mut matrix = initialize_matrix(n, m);

    // Populate the matrix with some data
    matrix[0][0] = vec!["apple".to_string(), "banana".to_string()];
    matrix[0][1] = vec!["orange".to_string()];
    matrix[1][1] = vec!["banana".to_string(), "grape".to_string()];
    matrix[2][2] = vec!["apple".to_string()];

    let target = "grape";
    match bfs_search(&matrix, target) {
        Some(steps) => println!("Found '{}' in {} steps.", target, steps),
        None => println!("'{}' not found.", target),
    }
}

// /**
//  * 6 Degrees of Kevin Bacon!
//  **/
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

//     // Write an answer using println!("message...");
//     // To debug: eprintln!("Debug message...");

     println!("N degrees to Kevin Bacon");
}