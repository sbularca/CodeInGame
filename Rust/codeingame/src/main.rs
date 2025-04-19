use pong::GameState;
use ggez::GameResult;

mod six_degrees;
mod island_escape;
mod simple_programs;
mod pong;

fn main() -> GameResult {
    println!("Executing...");
    //six_degrees::six_degrees();
    //island_escape::island_escape();
    //simple_programs::sort();

    let (ctx, event_loop) = ggez::ContextBuilder::new("Pong", "Uzihead").build()?;

    let state = GameState::new();
    // Use the full path to event::run
    ggez::event::run(ctx, event_loop, state)

}
