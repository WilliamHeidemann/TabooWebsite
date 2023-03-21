using Microsoft.AspNetCore.Components;

namespace Taboo.Data;
public class CountdownTimer
{
    private bool _timerRunning;
    public string TimerText = "Start Timer";
    public string ButtonColor;

    public CountdownTimer()
    {
        ChangeColor();
    }

    public void TimerButton()
    {
        if(_timerRunning) StopTimer();
        else StartTimer();
        ChangeColor();
    }

    private void ChangeColor()
    {
        ButtonColor = _timerRunning 
            ? "background-color: #D70B5E;" 
            : "background-color: #1b6ec2";
    }

    private async void StartTimer()
    {
        _timerRunning = true;
        int timeRemaining = 60;
        while (timeRemaining > 1)
        {
            if (!_timerRunning) return;
            timeRemaining--;
            TimerText = timeRemaining.ToString();
            await Task.Delay(1000);
        }
        StopTimer();
    }

    private void StopTimer()
    {
        _timerRunning = false;
        ChangeColor();
        TimerText = "Start Timer";
    }
}