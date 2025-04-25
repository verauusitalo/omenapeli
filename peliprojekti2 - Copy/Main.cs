using Godot;
using System;

public class Main : Node2D
{
    [Export] public PackedScene AppleScene;

    private int score = 0;
    private float timeLeft = 60f;

    private Label scoreLabel;
    private Label timerLabel;

    public override void _Ready()
    {
        scoreLabel = GetNode<Label>("UI/ScoreLabel");
        timerLabel = GetNode<Label>("UI/TimerLabel");

        SpawnApples(10);
        UpdateUI();

        GetNode<Timer>("Timer").WaitTime = 1;
        GetNode<Timer>("Timer").Connect("timeout", this, nameof(OnTimerTimeout));
        GetNode<Timer>("Timer").Start();
    }

    private void SpawnApples(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Apple apple = (Apple)AppleScene.Instance();
            apple.Position = new Vector2(
                GD.Randi() % 800, GD.Randi() % 600
            );
            AddChild(apple);
            apple.Connect("Collected", this, nameof(OnAppleCollected));
        }
    }

    private void OnAppleCollected()
    {
        score += 1;
        UpdateUI();
    }

    private void OnTimerTimeout()
    {
        timeLeft -= 1;
        UpdateUI();

        if (timeLeft <= 0)
        {
            GetNode<Timer>("Timer").Stop();
            GD.Print("Game Over!");
        }
    }

    private void UpdateUI()
    {
        scoreLabel.Text = $"Score: {score}";
        timerLabel.Text = $"Time: {Mathf.CeilToInt(timeLeft)}";
    }
}