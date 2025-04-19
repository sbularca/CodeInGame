use ggez::{Context, GameResult};
use ggez::event::EventHandler;

pub struct GameData{
    ball_position: [f32; 2],
    ball_speed: f32,

    paddle1_position: [f32; 2],
    paddle2_position: [f32; 2],

    paddle1_speed: f32,
    paddle2_speed: f32
}

pub struct GameState{
    game_data: GameData
}

impl GameState{
    pub fn new() -> Self{
        GameState {
            game_data : GameData{
                ball_position: [0.0, 0.0],
                ball_speed: 0.0,
                paddle1_position: [0.0, 0.0],
                paddle2_position: [0.0, 0.0],
                paddle1_speed: 0.0,
                paddle2_speed: 0.0
            }
        }
    }
}


impl EventHandler for GameState {
    fn update(&mut self, _ctx: &mut Context) -> Result<(), ggez::GameError> {
        Ok(())
    }

    fn draw(&mut self, _ctx: &mut Context) -> Result<(), ggez::GameError> {
        Ok(())
    }
}