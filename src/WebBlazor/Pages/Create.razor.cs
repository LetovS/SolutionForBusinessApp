using Microsoft.AspNetCore.Components;

namespace WebBlazor.Pages;

public class CreateModel : ComponentBase
{
    private System.Timers.Timer _timer;
    private const int _interval = 1000;

    public int Counter { get; set; }

    protected Task StartAsync()
    {
        _timer.Start();
        return Task.CompletedTask;
    }

    protected Task StopAsync()
    {
        _timer.Stop();
        return Task.CompletedTask;
    }

    protected Task PauseAsync()
    {
        _timer.Enabled = !_timer.Enabled;
        return Task.CompletedTask;
    }

    protected override Task OnInitializedAsync()
    {
        Counter = 10;
        return Task.CompletedTask;
    }
}