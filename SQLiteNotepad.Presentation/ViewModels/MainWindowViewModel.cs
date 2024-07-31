using System.Windows.Input;
using Microsoft.Extensions.Logging;
using SQLiteNotepad.ApplicationCore.Primitives.Interfaces;
using SQLiteNotepad.ApplicationCore.Primitives.Models;
using SQLiteNotepad.Presentation.Utils;

namespace SQLiteNotepad.Presentation.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public List<Note> Notes { get; set; }

    public Note Note
    {
        get => _note;
        set => SetField(ref _note, value);
    }
    
    public ICommand CreateNoteCommand { get; }
    public ICommand SaveNoteCommand { get; }
    public ICommand EditNoteCommand { get; }
    public ICommand DeleteNoteCommand { get; }

    private readonly INoteService _noteService;
    private Note _note;

    public MainWindowViewModel(ILogger<MainWindowViewModel> logger, INoteService noteService) : base(logger)
    {
        _noteService = noteService;

        Notes = _noteService.ToList().Result;

        CreateNoteCommand = new AsyncRelayCommand(x =>
        {
            Note = new Note();
        });

        EditNoteCommand = new AsyncRelayCommand(x =>
        {
            if (x is Note note)
            {
                Note = note;
            }
        });

        DeleteNoteCommand = new AsyncRelayCommand(async x =>
        {
            if (x is Note note)
            {
                await _noteService.RemoveNote(note);
                Notes.Remove(note);
            }
        });
        
        _logger.LogInformation("MainWindowViewModel initialized");
    }
}