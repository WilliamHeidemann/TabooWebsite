using Microsoft.AspNetCore.Components;

namespace Taboo.Data;
public class CountdownTimer
{
    private bool _timerRunning;
    public string TimerText = "Start Timer";

    public void TimerButton()
    {
        if(_timerRunning) StopTimer();
        else StartTimer();
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
        TimerText = "Start Timer";
    }
}