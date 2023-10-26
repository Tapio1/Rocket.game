using Godot;
using System;
using System.Threading;
public partial class Main : Node
{
	[Export]
    public PackedScene coinScene {get;set;}
	[Export]
	public PackedScene enemyScene {get;set;}

	// Called when the node enters the scene tree for the first time.

	
	public override void _Ready()
	{
		NewGame();
	}

	public void NewGame(){
		Player player = GetNode<Player>("Player");
		Marker2D playerSpawn = GetNode<Marker2D>("PlayerSpawn");

		Ground ground = GetNode<Ground>("Ground");
		Marker2D groundSpawn = GetNode<Marker2D>("GroundSpawn");

		//Coin coin = GetNode<Coin>("Coin");
		//Marker2D coinSpawn = GetNode<Marker2D>("CoinSpawn");
		//coin.Position = coinSpawn.Position;

		player.Position = playerSpawn.Position;
		ground.Position = groundSpawn.Position;

		GetNode<Godot.Timer>("Timer").Start();
		GetNode<Godot.Timer>("TimerEnemy").Start();	
		GetNode<Godot.Timer>("TimerEnemyJump").Start();
	}

	private void OnCoinSpawn()
	{
		//Coin coin = GetNode<Coin>("Coin");
		
		Coin coin = coinScene.Instantiate<Coin>();

		Marker2D coinSpawn = GetNode<Marker2D>("CoinSpawnPosition");
		var position = coinSpawn.Position;
		position.Y += Mathf.Round(GD.RandRange(-20, 20)) * 9;
		coin.Position = position;
		AddChild(coin);
	}

	private void OnEnemySpawn()
	{
		
		Enemy enemy = enemyScene.Instantiate<Enemy>();
		Marker2D enemySpawn = GetNode<Marker2D>("EnemySpawn");
		var position = enemySpawn.Position;
		position.Y += Mathf.Round(GD.RandRange(-20, 20)) * 2;
		enemy.Position = position;
		AddChild(enemy);
		/*
		Enemy enemy = GetNode<Enemy>("Enemy");
		
		Marker2D enemySpawn = GetNode<Marker2D>("EnemySpawn");
		enemy.Position = enemySpawn.Position;
       */
		
	}

	

	public void Score(){

	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
